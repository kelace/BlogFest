using MediatR;
using BlogFest.Domain.Users;
using BlogFest.Domain.Base;
using BlogFest.Application.Abstract;

namespace BlogFest.Application.Services.Configuration.Commands.EditUserInformation
{
    public class EditUserInformationCommandHandler : IRequestHandler<EditUserInformationCommand, Result<Guid, Error>>
    {
        private IUserRepository _userRepository;
        private IUserImageLoader _imageLoader;
        private IUnitOfWork _unitOfWork;
        private readonly IUserContext _userContext;
        public EditUserInformationCommandHandler(IUserRepository userRepository, IUserImageLoader imageLoader, IUnitOfWork unitOfWork, IUserContext userContext)
        {
            _userRepository = userRepository;
            _imageLoader = imageLoader;
            _unitOfWork = unitOfWork;
            _userContext = userContext;
        }

        public async Task<Result<Guid, Error>> Handle(EditUserInformationCommand request, CancellationToken cancellationToken)
        {
            string path = "";
            Result<Guid, Error> result;
            try
            {
                var user = await _userRepository.GetUserByIdAsync(_userContext.CurrentUserId);
                
                result = user.EditInformation(new UserInformation(request.FirstName, request.LastName, request.PhotoId, request.Bio));

                await _userRepository.Update(user);

                if (result.IsSuccess) await _unitOfWork.SaveAsync();

            }
            catch (Exception)
            {
                await _imageLoader.RemoveFileAsync(path);
                throw;
            }

            return result;
        }
    }
}
