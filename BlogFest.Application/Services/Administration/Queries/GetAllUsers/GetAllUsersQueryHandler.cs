using BlogFest.Application.Abstract;
using BlogFest.Application.Services.Administration.Queries.DTOs;
using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogFest.Application.Services.Administration.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<AdminUserForEditDTO>>
    {
        private readonly IUserContext _userContext;
        private readonly string _connection;
        public GetAllUsersQueryHandler(IUserContext userContext, IOptions<DbConfigurationOptions> options)
        {
            _userContext = userContext;
            _connection = options.Value.ConnectionString;
        }

        public async Task<List<AdminUserForEditDTO>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var sql = $@"

                SELECT Id, Name, Active as IsActived, IsCreatePostAllowed as IsCreatePostAllowed, IsCommentAllowed as IsCommentAllowed  FROM 
            {DbConstants.UserTable}
            WHERE Id != @CurrentUserId

            ";
            using (var connection = new SqlConnection(_connection))
            {
                var result = await connection.QueryAsync<AdminUserForEditDTO>(sql, new { CurrentUserId  = _userContext.CurrentUserId});
                return result.ToList();
            }
        }
    }
}
