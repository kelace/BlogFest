using BlogFest.Application.Abstract;
using BlogFest.Application.Services.Users.DTOs;
using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogFest.Application.Services.Users.Queries.GetAllNotification
{
    public class GetAllUserNotificationQueryHandler : IRequestHandler<GetAllUserNotificationQuery, List<NotificationDTO>>
    {
        private readonly IUserContext _userContext;
        private readonly string _connection;

        public GetAllUserNotificationQueryHandler(IUserContext userContext, IOptions<DbConfigurationOptions> connection)
        {
            _userContext = userContext;
            _connection = connection.Value.ConnectionString;
        }

        public async Task<List<NotificationDTO>> Handle(GetAllUserNotificationQuery request, CancellationToken cancellationToken)
        {
            var sql = $@"


                SELECT * FROM {DbConstants.NotificationTable} WHERE UserId = @UserId
                ORDER BY DateCreated DESC;

            ";

            using(var connection = new SqlConnection(_connection))
            {
                var result = await connection.QueryAsync<NotificationDTO>(sql, new { UserId = _userContext.CurrentUserId });
                return result.ToList();
            }
        }
    }
}
