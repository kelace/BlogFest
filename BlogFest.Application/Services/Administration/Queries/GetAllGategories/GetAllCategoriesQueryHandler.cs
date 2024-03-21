using BlogFest.Application.Abstract;
using BlogFest.Application.Services.Administration.Queries.DTOs;
using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogFest.Application.Services.Administration.Queries.GetAllGategories
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, List<CategoryDTO>>
    {
        private readonly IUserContext _userContext;
        private readonly string _connection;
        public GetAllCategoriesQueryHandler(IUserContext userContext, IOptions<DbConfigurationOptions> options)
        {
            _userContext = userContext;
            _connection = options.Value.ConnectionString;
        }

        public async Task<List<CategoryDTO>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var sql = $@"

    
                SELECT * FROM {DbConstants.CategoryTable};


            ";
            using(var connection = new SqlConnection(_connection))
            {
                var result = await connection.QueryAsync<CategoryDTO>(sql);
                return result.ToList();
            }
        }
    }
}
