using BlogFest.Application.Services.Search.Queries.DTOs;
using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;

namespace BlogFest.Application.Services.Search.Queries.SearchContent
{
    public class SearchContentQueryHandler : IRequestHandler<SearchContentQuery, SearchDTO>
    {
        private readonly string _connection;
        public SearchContentQueryHandler(IOptions<DbConfigurationOptions> options)
        {
            _connection = options.Value.ConnectionString;
        }
        public async Task<SearchDTO> Handle(SearchContentQuery request, CancellationToken cancellationToken)
        {
            var result = new SearchDTO();
            using (var connection = new SqlConnection(_connection))
            {
                var sql = @$"

                select count(s.Id) from (

                    SELECT Id FROM dbo.Posts
                    WHERE
                    Title LIKE @key or ContentText LIKE @key
                    and Title != 'Draft'
                
                    UNION

                    SELECT Id FROM dbo.Users
                    WHERE
                    Name Like @key
                ) as s;
  
                SELECT src.Id, src.SearchItemType, src.Content, src.Title, src.ImagePath, src.Slug, src.DateCreated from (

                    SELECT p.Id, @PostType as SearchItemType, p.Title, SUBSTRING(p.ContentText, 0, 200) as Content, ISNULL(f.Path, df.Path) as ImagePath, p.No, p.Slug, p.DateCreated FROM dbo.Posts p
                    LEFT JOIN dbo.PostFiles as pf on p.Id = pf.PostId and pf.Active = 1
                    LEFT JOIN dbo.Files as f on pf.FileId = f.Id
                    LEFT JOIN dbo.Files as df on df.Name = 'Default-image-title-preview'
                    WHERE
                    p.Title LIKE @key or ContentText LIKE @key
                    and Title != 'Draft'
                
                    UNION

                    SELECT u.Id, @UserType as SearchItemType, u.Name as Title, u.Bio as Content, ISNULL(f.Path, df.Path) as ImagePath, u.No, u.Name, u.DateCreated  FROM dbo.Users as u
                    LEFT JOIN dbo.UserFiles as uf on u.Id = uf.UserId and uf.Choosed = 1
                    LEFT JOIN dbo.Files as f on uf.FileId = f.Id
                    LEFT JOIN dbo.Files as df on df.Name = 'Default-Image'
                    WHERE
                    u.Name Like @key
                    ) as src
                    order by src.No desc
                    offset @offset rows fetch next 3 rows only
                ";

                using (var reader = await connection.QueryMultipleAsync(sql, new
                {
                    key = $"%{request.Key}%",
                    UserType = SearchItemType.User,
                    PostType = SearchItemType.Post,
                    CategoryType = SearchItemType.Category,
                    offset = (request.Page - 1) * 3
                }))
                {
                    result.Count = await reader.ReadFirstOrDefaultAsync<int>();
                    var searchEnumerble = await reader.ReadAsync<SearchItemDTO>();
                    result.SearchResult = searchEnumerble.ToList();
                }


                result.Page = request.Page;
                result.Key = request.Key;
                return result;

            }
        }
    }
}
