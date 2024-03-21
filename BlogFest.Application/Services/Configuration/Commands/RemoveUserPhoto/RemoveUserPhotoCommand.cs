using BlogFest.Application.Services.Abstract;
using BlogFest.Domain.Base;
using MediatR;

namespace BlogFest.Application.Services.Configuration.Commands.RemoveUserPhoto
{
    public class RemoveUserPhotoCommand : IRequest<Result<SuccessInfo, Error>>, IApplicationCommand
    {
        public Guid PhotoFileId { get; set; }
    }
}
