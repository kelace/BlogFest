using BlogFest.Domain.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogFest.Application.Configuration.Commands.UploadUserImage
{
    public class UploadUserImageCommand : IRequest<Result<(Guid, Guid, string), Error>>
    {
        public byte[] Photo { get; set; }
    }
}
