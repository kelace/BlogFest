using BlogFest.Application.Services.Administration.Queries.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogFest.Application.Services.Administration.Queries.GetAllGategories
{
    public class GetAllCategoriesQuery : IRequest<List<CategoryDTO>>
    {
    }
}
