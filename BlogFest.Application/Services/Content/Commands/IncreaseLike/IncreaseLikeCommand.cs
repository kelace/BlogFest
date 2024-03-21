using MediatR;
using BlogFest.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogFest.Application.Services.Content.Commands.IncreaseLike
{
    public class IncreaseLikeCommand : IRequest<Result<bool, Error>>
    {
        public Guid PostId { get; set; }
    }
}
