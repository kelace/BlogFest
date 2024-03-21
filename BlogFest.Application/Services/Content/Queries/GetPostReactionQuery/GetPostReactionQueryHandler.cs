using AutoMapper;
using MediatR;
using BlogFest.Application.Services.Content.Queries.DTOs;
using BlogFest.Application.Abstract;
using Microsoft.Data.SqlClient;
using System.Data.Common;
using Microsoft.Extensions.Options;
using Dapper;

namespace BlogFest.Application.Services.Content.Queries.GetPostReactionQuery
{
    public class GetPostReactionQueryHandler : IRequestHandler<GetPostReactionQuery, ReactionDTO>
    {
        private readonly string _connection;
        private readonly IUserContext _userContext;

        public GetPostReactionQueryHandler
            (
            IUserContext userContext,
            IOptions<DbConfigurationOptions> options)
        {
            _connection = options.Value.ConnectionString;
            _userContext = userContext;
        }

        public async Task<ReactionDTO> Handle(GetPostReactionQuery request, CancellationToken cancellationToken)
        {
            var model = new ReactionDTO();

            using (var connection = new SqlConnection(_connection))
            {
                var sql = @"

                  select count(pr.PostId) from [dbo].[PostReactions] pr
                  join dbo.ReactionType rt on pr.ReactionTypeId =  rt.Id
                  where rt.Description = 'Like' and PostId = @PostId
                  group by PostId, ReactionTypeId

                  select count(pr.PostId) from [dbo].[PostReactions] pr
                  join dbo.ReactionType rt on pr.ReactionTypeId =  rt.Id
                  where rt.Description = 'Dislike' and PostId = @PostId
                  group by PostId, ReactionTypeId

                  select rt.Description from dbo.PostReactions pr
                  join dbo.ReactionType rt on pr.ReactionTypeId = rt.Id
                  where UserId = @UserId
                  and PostId = @PostId

                ";

                using (var reader = await connection.QueryMultipleAsync(sql, new { PostId = request.PostId, UserId = _userContext.CurrentUserId }))
                {
                    model.LikesCount = await reader.ReadSingleOrDefaultAsync<int>();
                    model.DislikesCount = await reader.ReadSingleOrDefaultAsync<int>();
                    model.Type = await reader.ReadSingleOrDefaultAsync<string>();
                }

                return model;
            }
        }
    }
}
