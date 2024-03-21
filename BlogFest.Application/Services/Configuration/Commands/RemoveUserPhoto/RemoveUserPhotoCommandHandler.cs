using BlogFest.Application.Abstract;
using BlogFest.Domain.Base;
using MediatR;

namespace BlogFest.Application.Services.Configuration.Commands.RemoveUserPhoto
{
    public class RemoveUserPhotoCommandHandler : IRequestHandler<RemoveUserPhotoCommand, Result<SuccessInfo, Error>>
    {
        private readonly IUserImageLoader _imageLoader;
        private readonly IUnitOfWork _unitOfWork;
        public RemoveUserPhotoCommandHandler(IUserImageLoader imageLoader, IUnitOfWork unitOfWork)
        {
            _imageLoader = imageLoader;
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<SuccessInfo, Error>> Handle(RemoveUserPhotoCommand request, CancellationToken cancellationToken)
        {
            await _imageLoader.RemoveFileAsync(request.PhotoFileId);
            await _unitOfWork.SaveAsync();
            return new SuccessInfo();
        }
    }
}
