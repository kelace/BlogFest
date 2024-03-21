using MediatR;
using BlogFest.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogFest.Application.Services.Media.Results;

namespace BlogFest.Application.Services.Content.Commands.UploadTitleImage
{
    public class UploadTitleImageCommand : IRequest<Result<SuccesUploadResult, Error>>
    {
        public byte[] Image { get; set; }
        public Guid PostId { get; set; }

    }
}
