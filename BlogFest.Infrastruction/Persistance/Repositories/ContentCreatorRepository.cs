using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using BlogFest.Data;
using BlogFest.Infrastruction.Persistance.Factories;
using BlogFest.Domain.Content.ContentCreating;
using BlogFest.Infrastruction.Persistance.DataModels;
using Microsoft.Extensions.Caching.Memory;

namespace BlogFest.Infrastructure.Persistance.Repositories
{
    public class ContentCreatorRepository : IContentCreatorRepository
    {
        ApplicationDbContext _context;
        IDomainEventStorage _eventSrorage;
        IMediator _mediator;
        IMemoryCache _memoryCache;

        public ContentCreatorRepository(ApplicationDbContext context, IDomainEventStorage eventSrorage, IMediator mediator, IMemoryCache memoryCache)
        {
            _context = context;
            _eventSrorage = eventSrorage;
            _mediator = mediator;
            _memoryCache = memoryCache;
        }
        public async Task<ContentCreator> GetContentCreatorById(Guid id)
        {
            return await _context.Users.Include(x => x.Posts).Where(x => x.Id == id).Select(x => ContentDataDomainFactory.CreateContentCreator(x)).FirstOrDefaultAsync();
        }

		public async Task<string> GetSlugForPost(Guid id)
		{
            return await _context.Posts.Where(x => x.Id == id).Select(x => x.Slug).FirstOrDefaultAsync();
		}

		public async Task UpdateAsync(ContentCreator contentCreator)
        {
            var events = contentCreator.GetEvents();
            contentCreator.ClearEvents();

            foreach (var @event in events)
            {
                if (@event is PostHasBeenEdited)
                {
                    
                    var domainEvent = (PostHasBeenEdited)@event;
                    var oldSlug = await _context.Posts.Where(x => x.Id == domainEvent.PostId).Select(x => x.Slug).FirstOrDefaultAsync();
                    object[] paramItems = new object[]
                       {
                            new SqlParameter("@PostId", domainEvent.PostId) ,
                            new SqlParameter("@ContentText", domainEvent.ContentText),
                            new SqlParameter("@ContentHTML", domainEvent.ContentHTML),
                            new SqlParameter("@PostStatus", domainEvent.Status.ToString()),
                            new SqlParameter("@Title", domainEvent.Title),
                            new SqlParameter("@ImageId", domainEvent.ImageId),
                            new SqlParameter("@Slug", domainEvent.Slug),
                       };

                    var sql = @"

                    declare @uniqSlugCount int;
                    declare @SlugWithNumber varchar(100);
                    declare @SlugFinal varchar(255);

                    select @uniqSlugCount = Count(Id) from dbo.Posts where TitleSlugify = @Slug and Id != @PostId;

                    set @SlugWithNumber = @Slug + '-' + CAST(@uniqSlugCount + 1 AS VARCHAR(100));

                    set @SlugFinal = IIF(@uniqSlugCount > 0, @SlugWithNumber , @Slug);

                    set @SlugWithNumber = @Slug + '-' + CAST(@uniqSlugCount + 1 AS VARCHAR(100));
                    update dbo.Posts set ContentText = @ContentText, ContentHTML = @ContentHTML, PostStatus = @PostStatus, Title = @Title, TitleSlugify = @Slug, Slug = @SlugFinal where Id = @PostId";
              
                    await _context.Database.ExecuteSqlRawAsync(sql, new object[]
                       {
                            new SqlParameter("@PostId", domainEvent.PostId) ,
                            new SqlParameter("@ContentText", domainEvent.ContentText),
                            new SqlParameter("@ContentHTML", domainEvent.ContentHTML),
                            new SqlParameter("@PostStatus", domainEvent.Status.ToString()),
                            new SqlParameter("@Title", domainEvent.Title),
                            new SqlParameter("@Slug", domainEvent.Slug),
                       });

                    if(domainEvent.Categories != null)
                    {
						var categoriesPostsToRemove = await _context.CategoriesPosts.Where(x => !domainEvent.Categories.Contains(x.Id)).ToListAsync();
						var categoriesPostsToAdd = domainEvent.Categories.Select(x =>
						{
							return new CategoryPostDataModel
							{
								CategoryId = x,
								PostId = domainEvent.PostId
							};
						});

						_context.RemoveRange(categoriesPostsToRemove);
						await _context.AddRangeAsync(categoriesPostsToAdd);
					}

             

                    if (domainEvent.ImageId != null)
                    {
                        var removeImagesSql = "update dbo.PostFiles set Active = 0 where PostId = @PostId";
                        var addImageIdSql = "update dbo.PostFiles set Active = 1 where PostId = @PostId and FileId = @ImageId";

                        await _context.Database.ExecuteSqlRawAsync(removeImagesSql, new object[]
                           {
                            new SqlParameter("@PostId", domainEvent.PostId)

                           });

                        await _context.Database.ExecuteSqlRawAsync(addImageIdSql, new object[]
                        {
                             new SqlParameter("@PostId", domainEvent.PostId),
                                  new SqlParameter("@ImageId", domainEvent.ImageId),
                        });    
                    }

                    RefreshCacheBySlug(oldSlug);
                }

                if (@event is PostHasBeenCreated)
                {
                    var domainEvent = (PostHasBeenCreated)@event;
                    object[] paramItems = new object[]
                       {
                            new SqlParameter("@Id", domainEvent.Id) ,
                            new SqlParameter("@Content", domainEvent.Content),
                            new SqlParameter("@ContentHTML", domainEvent.Content),
                            new SqlParameter("@Title", domainEvent.Title),
                            new SqlParameter("@Status", domainEvent.Status.ToString()),
                            new SqlParameter("@UserId", domainEvent.UserId),
                            new SqlParameter("@Slug", domainEvent.Slug),
                       };

                    var sql = @"
    
                    declare @uniqSlugCount int;
                    declare @SlugWithNumber varchar(100);
                    declare @SlugFinal varchar(255);

                    
                    select @uniqSlugCount = Count(Id) from dbo.Posts where TitleSlugify = @Slug;

                    set @SlugWithNumber = @Slug + '-' + CAST(@uniqSlugCount + 1 AS VARCHAR(100));

                    set @SlugFinal = IIF(@uniqSlugCount > 0, @SlugWithNumber , @Slug);

                    insert into dbo.Posts (Id, ContentText, Title, PostStatus, UserId, ContentHTML, Slug, TitleSlugify) VALUES(@Id, @Content, @Title, @Status, @UserId, @ContentHTML, @SlugFinal, @Slug )

                    ";

                    await _context.Database.ExecuteSqlRawAsync(sql, paramItems);
                }

                if (@event is PostHasBeenPublishedEvent)
                {
                    var domainEvent = (PostHasBeenPublishedEvent)@event;
                    var oldSlug = await _context.Posts.Where(x => x.Id == domainEvent.Id).Select(x => x.Slug).FirstOrDefaultAsync();
                    object[] paramItems = new object[]
                    {
                            new SqlParameter("@Id", domainEvent.Id) ,
                            new SqlParameter("@Status", domainEvent.Status.ToString()),
                    };

                    var sqlCommand = $@"UPDATE dbo.Posts set PostStatus = @Status where Id = @Id";
    
                    await _context.Database.ExecuteSqlRawAsync(sqlCommand, paramItems);
                    RefreshCacheBySlug(oldSlug);
                }
            }
        }

        private void RefreshCacheBySlug(string slug)
        {
            if(_memoryCache.TryGetValue($"post-{slug}", out var value))
            {
                _memoryCache.Remove(slug);
            }
        }
    }
}
