﻿using BlogFest.Data;
using BlogFest.Infrastruction.Persistance.DataModels;
using BlogFest.Infrastruction.Persistance.Factories;
using BlogFest.Infrastructure.Persistance;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using BlogFest.Domain.Content.ContentConsuming;
using BlogFest.Domain.Content.ContentCreating;
using BlogFest.Infrastruction.Persistance.Factories.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace BlogFest.Infrastruction.Persistance.Repositories
{
    public class ContentConsumerRepository : IContentConsumerRepository
    {
        ApplicationDbContext _context;
        IDomainEventStorage _eventSrorage;
        IMediator _mediator;
        IMemoryCache _memoryCache;

        public ContentConsumerRepository(ApplicationDbContext context, IDomainEventStorage eventSrorage, IMediator mediator, IMemoryCache memoryCache)
        {
            _context = context;
            _eventSrorage = eventSrorage;
            _mediator = mediator;
            _memoryCache = memoryCache;
        }

        public async Task<ContentConsumer> GetContentConsumerById(Guid id, Guid postId)
        {
            return await (from u in _context.Users
                          from p in _context.Posts.Where(x => x.Id == postId)
                          where u.Id == id
                          select ContentConsumerDataDomainFactory.CreateContentConsumer(u, p)).FirstOrDefaultAsync();

        }

        public async Task UpdateAsync(ContentConsumer consumer)
        {
            var events = consumer.GetEvents();
            consumer.ClearEvents();

            foreach (var @event in events)
            {
                if (@event is DislikeHasBeenPutEvent)
                {
                    var domainEvent = (DislikeHasBeenPutEvent)@event;
                    var dislikelikeId = await _context.ReactionType.Where(x => x.Description == "Dislike").Select(x => x.Id).FirstOrDefaultAsync();

                    var prev = await _context.PostReactions.Where(x => x.PostId == domainEvent.PostId && x.UserId == domainEvent.UserId).FirstOrDefaultAsync();

                    var reaction = new PostReactionData
                    {
                        Id = Guid.NewGuid(),
                        UserId = domainEvent.UserId,
                        PostId = domainEvent.PostId,
                        ReactionTypeId = dislikelikeId
                    };

                    if (prev != null) _context.PostReactions.Remove(prev);
                    await _context.PostReactions.AddAsync(reaction);
                }

                if (@event is LikeHasBeenPutEvent)
                {
                    var domainEvent = (LikeHasBeenPutEvent)@event;
                    var likeId = await _context.ReactionType.Where(x => x.Description == "Like").Select(x => x.Id).FirstOrDefaultAsync();

                    var prev = await _context.PostReactions.Where(x => x.PostId == domainEvent.PostId && x.UserId == domainEvent.UserId).FirstOrDefaultAsync();

                    var reaction = new PostReactionData
                    {
                        Id = Guid.NewGuid(),
                        UserId = domainEvent.UserId,
                        PostId = domainEvent.PostId,
                        ReactionTypeId = likeId
                    };

                    if (prev != null) _context.PostReactions.Remove(prev);
                    await _context.PostReactions.AddAsync(reaction);
                }

                if (@event is CommentHasBeenAdded)
                {
                    var domainEvent = (CommentHasBeenAdded)@event;

                    object[] paramItems = new object[]
                    {
                            new SqlParameter("@Id", Guid.NewGuid()) ,
                            new SqlParameter("@Content", domainEvent.Content),
                            new SqlParameter("@UserId", domainEvent.UserId),
                            new SqlParameter("@PostId", domainEvent.PostId),
                            new SqlParameter("@DateCreated", DateTime.UtcNow),
                    };

                    try
                    {
                        await _context.Database.ExecuteSqlRawAsync($@"

                            Insert Into [dbo].[Comments] (Id, Content, UserId, PostId, DateCreated)
                            Values(@Id, @Content, @UserId, @PostId, @DateCreated)", paramItems

                        );
                    }
                    catch (Exception ex)
                    {

                        throw;
                    }
                }
            }
        }

        private void RefreshCacheBySlug(string slug)
        {
            if (_memoryCache.TryGetValue($"post-{slug}", out var value))
            {
                _memoryCache.Remove(slug);
            }
        }
    }
}
