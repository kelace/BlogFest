using BlogFest.Application.Services.Administration.Queries.DTOs;
using BlogFest.Domain.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogFest.Application.Services.Administration.Commands.AddCategories
{
    public class AddOrUpdateCategoriesCommand : IRequest<Result<SuccessInfo, Error>>
    {
        public List<CategoryDTO> Categories { get; set; }
    }
}
