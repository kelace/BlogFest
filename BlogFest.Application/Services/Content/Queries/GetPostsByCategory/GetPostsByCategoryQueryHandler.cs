using MediatR;
using BlogFest.Application.Services.Content.Queries.DTOs;
using Microsoft.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Options;
using BlogFest.Domain.Content;

namespace BlogFest.Application.Services.Content.Queries.GetPostsByCategory
{
    public class GetPostsByCategoryQueryHandler : IRequestHandler<GetPostsByCategoryQuery, List<PostDTO>>
    {
        private readonly string _connection;
        public GetPostsByCategoryQueryHandler(IOptions<DbConfigurationOptions> options)
        {
            _connection = options.Value.ConnectionString;
        }

        public async Task<List<PostDTO>> Handle(GetPostsByCategoryQuery request, CancellationToken cancellationToken)
        {
            var sql = $@"
                SELECT *, ISNULL(f.Path, fd.Path) as ImagePath, SUBSTRING(p.ContentText, 0, 200) as Text, u.Id as UserId, u.Name as UserName FROM {DbConstants.CategoryTable} c
                    JOIN {DbConstants.CategoryPostTable} cp ON c.Id = cp.CategoryId
                    JOIN {DbConstants.PostTable} p ON cp.PostId = p.Id
             JOIN {DbConstants.UserTable} u on p.UserId = u.Id
             LEFT JOIN {DbConstants.PostFileTable} pf on p.Id = pf.PostId and pf.Active = 1
                        LEFT JOIN {DbConstants.FileTable} f on pf.FileId = f.id
                        LEFT JOIN {DbConstants.FileTable} fd on fd.Name = 'Default-image-title-preview'
                        WHERE p.PostStatus != @DraftStatus
                        and c.Title = @Category;
            ";

            using(var connection = new SqlConnection(_connection))
            {
                var result = await connection.QueryAsync<PostDTO>(sql, new {Category = request.CategoryTitle, DraftStatus = PostStatus.Draft.ToString() });

                return result.ToList();
            }
        }
    }
}
