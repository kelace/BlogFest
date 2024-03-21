using BlogFest.Domain.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogFest.Application.Services.Content.Commands.PublishPost
{
    public class PublishPostCommand : IRequest<Result<SuccessInfo, Error>>
    {
        public Guid PostId { get; set; }
    }
}
