using MediatR;
using BlogFest.Application.Services.Content.Queries.DTOs;
using Microsoft.Extensions.Options;
using Microsoft.Data.SqlClient;
using Dapper;

namespace BlogFest.Application.Services.Content.Queries.GetPostCommentsQuery
{
    public class GetPostCommentsQueryHandler : IRequestHandler<GetPostCommentsQuery, PostCommentsDTO>
    {
        private readonly string _connection;
        public GetPostCommentsQueryHandler(IOptions<DbConfigurationOptions> options)
        {
            _connection = options.Value.ConnectionString;
        }
        public async Task<PostCommentsDTO> Handle(GetPostCommentsQuery request, CancellationToken cancellationToken)
        {

            var sql = $@"
        
             SELECT c.Id, c.Content, c.PostId, ISNULL(f.Path, fd.Path) as Path, c.DateCreated, u.Id as UserId, u.Name as UserName FROM {DbConstants.CommentTable} c
                JOIN {DbConstants.PostTable} p ON c.PostId = p.Id
                JOIN {DbConstants.UserTable} u ON c.UserId = u.Id
                LEFT JOIN {DbConstants.UserFileTable} uf on u.Id = uf.UserId and uf.Choosed = 1
                LEFT JOIN {DbConstants.FileTable} f on uf.FileId = f.Id
                LEFT JOIN {DbConstants.FileTable} fd on fd.Name = 'Default-Image'
            
             WHERE p.Id = @Id
                ORDER BY c.DateCreated desc;


             SELECT COUNT(c.Id) FROM {DbConstants.CommentTable} c
                WHERE c.PostId = @Id
            ";

            var model = new PostCommentsDTO();

            using (var connection = new SqlConnection(_connection))
            {
                using(var reader = await connection.QueryMultipleAsync(sql, new { Id = request.PostId }))
                {
                    var commentsReadResult = await reader.ReadAsync<CommentDto>();
                    var commonReadResult = await reader.ReadSingleAsync<int>();

                    model.Comments = commentsReadResult.ToList();
                    model.TotalAmount = commonReadResult;
                    model.Offset = request.Offset + 3;

                    return model;
                }   
            }
        }
    }
}
