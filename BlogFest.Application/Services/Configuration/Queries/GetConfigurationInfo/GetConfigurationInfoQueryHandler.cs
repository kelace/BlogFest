using AutoMapper;
using BlogFest.Application.Abstract;
using BlogFest.Application.Configuration.Queries;
using BlogFest.Application.Services.Configuration.Queries.DTOs;
using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;

namespace BlogFest.Application.Services.Configuration.Queries.GetConfigurationInfo
{
    public class GetConfigurationInfoQueryHandler : IRequestHandler<GetConfigurationInfoQuery, UserConfigurationDto>
    {

        private readonly string _connection;

        public GetConfigurationInfoQueryHandler(IOptions<DbConfigurationOptions> options)
        {
            _connection = options.Value.ConnectionString;
        }
        public async Task<UserConfigurationDto> Handle(GetConfigurationInfoQuery request, CancellationToken cancellationToken)
        {
            var sql = $@"

               SELECT
                u.Id AS UserId,
                u.Name AS UserName,
                u.FirstName,
                u.LastName,
                uf.Id as PhotoFileId,
                CASE
                    WHEN f.Id IS NULL THEN df.Path
                    ELSE f.Path
                END AS ImagePath,
                u.Bio AS UserBio
            FROM
                {DbConstants.UserTable} u
                LEFT JOIN {DbConstants.UserFileTable} uf ON u.Id = uf.UserId AND uf.Choosed = 1
                LEFT JOIN {DbConstants.FileTable} f ON uf.FileId = f.Id
                LEFT JOIN {DbConstants.FileTable} df ON df.Name = 'Default-Image'
            WHERE
                u.Id = @UserId
            ORDER BY
                uf.DateCreated DESC;

            ";

            using(var connection = new SqlConnection(_connection))
            {
                return await connection.QuerySingleAsync<UserConfigurationDto>(sql, new {UserId = request.UserId});
            }
        }
    }
}
