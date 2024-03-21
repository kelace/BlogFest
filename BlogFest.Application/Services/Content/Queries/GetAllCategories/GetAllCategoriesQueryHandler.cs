using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using Dapper;
using BlogFest.Application.Services.Administration.Queries.DTOs;

namespace BlogFest.Application.Services.Content.Queries.GetAllCategories
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, List<CategoryDTO>>
    {
        private readonly string _connection;

        public GetAllCategoriesQueryHandler(IOptions<DbConfigurationOptions> options)
        {
            _connection = options.Value.ConnectionString;
        }

        public async Task<List<CategoryDTO>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {

            var sql = $@"select c.* from {DbConstants.CategoryTable}";

            using(var connection = new SqlConnection(_connection))
            {
                var result = await connection.QueryAsync<CategoryDTO>(sql);
                return result.ToList();
            }
        }
    }
}
