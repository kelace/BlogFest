using MediatR;
using BlogFest.Application.Services.Content.Queries.DTOs;
using Microsoft.Extensions.Options;
using Microsoft.Data.SqlClient;
using Dapper;
using BlogFest.Application.Services.Administration.Queries.DTOs;

namespace BlogFest.Application.Services.Content.Queries.GetPostInfoForEdit
{
    public class GetPostInfoForEditQueryHandler : IRequestHandler<GetPostInfoForEditQuery, PostEditDTO>
    {
        private readonly string _connection;
        public GetPostInfoForEditQueryHandler(IOptions<DbConfigurationOptions> options)
        {
            _connection = options.Value.ConnectionString;
        }
        public async Task<PostEditDTO> Handle(GetPostInfoForEditQuery request, CancellationToken cancellationToken)
        {

            var sql = $@"
                SELECT p.Id, p.Title, p.ContentText, p.ContentHTML, p.UserId, p.DateCreated, p.PostStatus as Status, f.Path as ImagePath, wc.*, IIF(wc.Id = cp.CategoryId, 1, 0) as Selected  FROM {DbConstants.PostTable} p
                    LEFT JOIN {DbConstants.CategoryPostTable} cp ON p.Id = cp.PostId
                    CROSS JOIN {DbConstants.CategoryTable} wc
                    LEFT JOIN {DbConstants.PostFileTable} pf ON p.Id = pf.PostId and pf.Active = 1
                    LEFT JOIN {DbConstants.FileTable} f ON f.Id = pf.FileId 
                WHERE p.Slug = @Slug
            ";

            var model = new PostEditDTO();
            var categories = new List<CategoryDTO>();
            using (var connection = new SqlConnection(_connection))
            {
                var postReadResult = await connection.QueryAsync<PostEditDTO, CategoryDTO, PostEditDTO>(
                sql, 
                (post, category) =>
                {
 
                    if (category != null && post != null)
                    {
                        categories.Add(category);
                    }

                    return post;
                }, 
                new {Slug = request.Slug});

                var post = postReadResult.GroupBy(x => x.Id).Select(x => x.FirstOrDefault() ).FirstOrDefault();
                post.Categories = categories;
                return post;
            }
        }
    }
}
