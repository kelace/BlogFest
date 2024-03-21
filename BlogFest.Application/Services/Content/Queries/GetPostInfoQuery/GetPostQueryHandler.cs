using AutoMapper;
using MediatR;
using BlogFest.Application.Services.Content.Queries.DTOs;
using Microsoft.Data.SqlClient;
using System.Data.Common;
using Microsoft.Extensions.Options;
using Dapper;
using BlogFest.Application.Services.Administration.Queries.DTOs;

namespace BlogFest.Application.Services.Content.Queries.GetThreadInfoQuery
{
    public class GetPostQueryHandler : IRequestHandler<GetPostQuery, PostPageDTO>
    {
        private readonly string _connection;

        public GetPostQueryHandler  
        (
            IOptions<DbConfigurationOptions> options
        )
        {
            _connection = options.Value.ConnectionString;
        }
        public async Task<PostPageDTO> Handle(GetPostQuery request, CancellationToken cancellationToken)
        {
            var sql = $@"
            SELECT p.Id, p.Title, p.ContentHTML as Content, u.Id as CreatedById, u.Name as CreatedByName, f.Path as ImagePath, c.Id, c.Title FROM {DbConstants.PostTable} p
                JOIN {DbConstants.UserTable} u on p.UserId = u.Id
                LEFT JOIN {DbConstants.PostFileTable} pf ON p.Id = pf.PostId and pf.Active = 1
                LEFT JOIN {DbConstants.FileTable} f ON pf.FileId = f.Id
                LEFT JOIN {DbConstants.CategoryPostTable} cp ON cp.PostId = p.Id
                LEFT JOIN {DbConstants.CategoryTable} c ON cp.CategoryId = c.Id
            WHERE p.Id = @Id;

            SELECT c.Id, c.Content, c.PostId, u.Id as UserId, u.Name as UserName FROM {DbConstants.CommentTable} c
                JOIN {DbConstants.PostTable} p ON c.PostId = p.Id
                JOIN {DbConstants.UserTable} u ON c.UserId = u.Id
                LEFT JOIN {DbConstants.UserFileTable} uf on u.Id = uf.UserId and uf.Choosed = 1
                LEFT JOIN {DbConstants.FileTable} f on uf.FileId = f.Id
                LEFT JOIN {DbConstants.FileTable} fd on fd.Name = 'Default-Image'
            WHERE p.Id = @Id;

            SELECT COUNT(c.Id) FROM {DbConstants.CommentTable} c
            JOIN {DbConstants.PostTable} p ON c.PostId = p.Id
            WHERE p.Id = @Id;
            ";

            var model = new PostPageDTO();

            using (var connection = new SqlConnection(_connection))
            {
                using (var reader = await connection.QueryMultipleAsync(sql, new { Id = request.PostId }))
                {
                    var postResult = reader.Read<PostPageDTO, CategoryDTO, PostPageDTO>((post, category) =>
                    {
                        if (category != null)
                        {
                            post.Categories.Add(category);
                        }

                        return post;
                    });

                    var post = postResult.GroupBy(x => x.Id).Select(x =>
                    {
                        return x.FirstOrDefault();
                    }).FirstOrDefault();


                    if (post == null) return null;

                    var comments = await reader.ReadAsync<CommentDto>();
                    var commentsCount = await reader.ReadSingleAsync<int>();



                    post.Comments = comments.ToList();
                    post.CommentsCommonAmount = commentsCount;

                    return post;
                }
            }
        }
    }
}
