using BlogFest.Domain.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogFest.Application.Services.Administration.Commands.DeleteCategory
{
    public class DeleteCategoryCommand : IRequest<Result<SuccessInfo, Error>>
    {
        public Guid Id { get; set; }
    }
}
