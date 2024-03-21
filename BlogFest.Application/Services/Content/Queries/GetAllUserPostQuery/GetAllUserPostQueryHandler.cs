using AutoMapper;
using MediatR;
using BlogFest.Domain.Users;
using BlogFest.Application.Services.Content.Queries.DTOs;
using BlogFest.Application.Abstract;
using BlogFest.Domain.Content;
using Microsoft.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Options;

namespace BlogFest.Application.Services.Content.Queries.GetAllUserThreadsQuery
{
    public class GetAllUserPostQueryHandler : IRequestHandler<GetAllUserPostsQuery, ExplorePostsDTO>
    {
        private readonly string _connection;

        public GetAllUserPostQueryHandler(IOptions<DbConfigurationOptions> options)
        {
            _connection = options.Value.ConnectionString;
        }
        public async Task<ExplorePostsDTO> Handle(GetAllUserPostsQuery request, CancellationToken cancellationToken)
        {
            var sql = $@"
                        SELECT *, ISNULL(f.Path, fd.Path) as ImagePath, SUBSTRING(p.ContentText, 0, 200) as Text, u.Id as UserId, p.DateCreated, u.Name as UserName FROM dbo.Posts p 
                        JOIN {DbConstants.UserTable} u on p.UserId = u.Id
                        LEFT JOIN {DbConstants.PostFileTable} pf on p.Id = pf.PostId and pf.Active = 1
                        LEFT JOIN {DbConstants.FileTable} f on pf.FileId = f.id
                        LEFT JOIN {DbConstants.FileTable} fd on fd.Name = 'Default-image-title-preview'
                        WHERE p.PostStatus != @DraftStatus
                        order by p.DateCreated desc
                        OFFSET @Offset ROWS
                        FETCH NEXT 3 ROWS ONLY;

                        select count(p.Id) from {DbConstants.PostTable} p
                        WHERE p.PostStatus != @DraftStatus;
                        ";

            var model = new ExplorePostsDTO();

            using (var connection = new SqlConnection(_connection))
            {

                using (var multi = connection.QueryMultiple(sql, new { Offset = (request.Offset - 1) * 3, DraftStatus = PostStatus.Draft.ToString() }))
                {
                    var posts = await multi.ReadAsync<PostDTO>();
                    var count = await multi.ReadFirstOrDefaultAsync<int>();

                    model.Count = count;
                    model.Posts = posts.ToList();
                }
            }

            return model;

        }
    }
}
