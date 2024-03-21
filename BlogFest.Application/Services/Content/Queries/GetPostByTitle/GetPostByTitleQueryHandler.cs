using BlogFest.Application.Services.Content.Queries.DTOs;
using MediatR;
using Microsoft.Extensions.Options;
using Microsoft.Data.SqlClient;
using Dapper;
using BlogFest.Application.Services.Administration.Queries.DTOs;

namespace BlogFest.Application.Services.Content.Queries.GetPostByTitle
{
    public class GetPostByTitleQueryHandler : IRequestHandler<GetPostByTitleQuery, PostPageDTO>
    {
        private readonly string _connection;
        public GetPostByTitleQueryHandler(IOptions<DbConfigurationOptions> options)
        {
            _connection = options.Value.ConnectionString;
        }
        public async Task<PostPageDTO> Handle(GetPostByTitleQuery request, CancellationToken cancellationToken)
        {

            var sql = $@"
            SELECT p.Id, p.Title, p.ContentHTML as Content, p.Slug, u.Id as CreatedById, u.Name as CreatedByName, f.Path as ImagePath, c.Id, c.Title FROM {DbConstants.PostTable} p
                JOIN {DbConstants.UserTable} u on p.UserId = u.Id
                LEFT JOIN {DbConstants.PostFileTable} pf ON p.Id = pf.PostId and pf.Active = 1
                LEFT JOIN {DbConstants.FileTable} f ON pf.FileId = f.Id
                LEFT JOIN {DbConstants.CategoryPostTable} cp ON cp.PostId = p.Id
                LEFT JOIN {DbConstants.CategoryTable} c ON cp.CategoryId = c.Id
            WHERE p.Slug = @Slug;

            SELECT c.Id, c.Content, c.PostId, ISNULL(f.Path, fd.Path) as Path, c.DateCreated, u.Id as UserId, u.Name as UserName FROM {DbConstants.CommentTable} c
                JOIN {DbConstants.PostTable} p ON c.PostId = p.Id
                JOIN {DbConstants.UserTable} u ON c.UserId = u.Id
                LEFT JOIN {DbConstants.UserFileTable} uf on u.Id = uf.UserId and uf.Choosed = 1
                LEFT JOIN {DbConstants.FileTable} f on uf.FileId = f.Id
                LEFT JOIN {DbConstants.FileTable} fd on fd.Name = 'Default-Image'
            
            WHERE p.Slug = @Slug
            ORDER BY c.DateCreated desc
            offset 0 rows
            fetch  next 3 rows only;

            SELECT COUNT(c.Id) FROM {DbConstants.CommentTable} c
            JOIN {DbConstants.PostTable} p ON c.PostId = p.Id
            WHERE p.Slug = @Slug;
            ";

            var model = new PostPageDTO();

            using(var connection = new SqlConnection(_connection))
            {
                using(var reader = await connection.QueryMultipleAsync(sql, new { Slug = request.Slug}))
                {
                    var categories = new List<CategoryDTO>();
                    var postResult =  reader.Read<PostPageDTO, CategoryDTO, PostPageDTO>((post, category) =>
                    {
                        if(category != null)
                        {
							categories.Add(category);
                        }

                        return post;
                    });

                    var post =  postResult.GroupBy(x => x.Id).Select(x =>
                    {
                        return x.FirstOrDefault();
                    }).FirstOrDefault();

                    if (post == null) return null;

                    var comments = await reader.ReadAsync<CommentDto>();
                    var commentsCount = await reader.ReadSingleAsync<int>();

                    post.Comments = comments.ToList();
                    post.CommentsCommonAmount = commentsCount;
                    post.Categories = categories;

                    return post;
                }
            }


            //var result = await _postProcedures.GetPostInfoByTitle(request.Slug);
            //return result;
        }
    }
}
