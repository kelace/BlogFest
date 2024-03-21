using MediatR;
using BlogFest.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogFest.Application.Services.Abstract;

namespace BlogFest.Application.Services.Content.Commands.CreateDraftPost
{
    public class CreateDraftPostCommand : IRequest<Result<SuccessInfo, Error>>, IApplicationCommand
    {
        public Guid UserId { get; set; }
    }
}
