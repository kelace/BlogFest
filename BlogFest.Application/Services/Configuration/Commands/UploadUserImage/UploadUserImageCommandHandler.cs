using BlogFest.Application.Abstract;
using BlogFest.Domain.Base;
using BlogFest.Domain.Users;
using MediatR;
using BlogFest.Application.Configuration.Commands.UploadUserImage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogFest.Application.Services.Configuration.Commands.UploadUserImage
{
    public class UploadUserImageCommandHandler : IRequestHandler<UploadUserImageCommand, Result<(Guid, Guid, string), Error>>
    {
        private IUserImageLoader _imageLoader;
        private IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        public UploadUserImageCommandHandler(IUserImageLoader imageLoader, IUnitOfWork unitOfWork, IUserRepository userRepository)
        {
            _imageLoader = imageLoader;
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }
        public async Task<Result<(Guid, Guid, string), Error>> Handle(UploadUserImageCommand request, CancellationToken cancellationToken)
        {
            var result = await _imageLoader.UploadFileAsync(request.Photo, "asdasd");

            try
            {
                await _unitOfWork.SaveAsync();
            }
            catch (Exception)
            {
                await _imageLoader.RemoveFileAsync(result.Value.Item1);
                throw;
            }

            return result;
        }
    }
}
