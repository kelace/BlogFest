using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogFest.Application.Behaviors.Abstract;
using BlogFest.Application.Services.Abstract;
using BlogFest.Application.Services.Administration.Queries.DTOs;

namespace BlogFest.Application.Services.Content.Queries.GetAllCategories
{
    public class GetAllCategoriesQuery : IRequest<List<CategoryDTO>>, ICacheable, IApplicationQuery
    {
        public string Key => $"categories";

        public string Slug => throw new NotImplementedException();
    }
}
