using BlogFest.Application.Abstract;
using BlogFest.Application.Shared;
using BlogFest.Domain.Base;
using BlogFest.Domain.Users;
using MediatR;


namespace BlogFest.Application.Services.Configuration.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Result<SuccessInfo, List<Error>>>
    {
        private readonly IApplicationAuthentication _authentication;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserContext _userContext;
        private readonly IUserRepository _userRepository;
        public DeleteUserCommandHandler(IApplicationAuthentication authentication, IUnitOfWork unitOfWork, IUserContext userContext, IUserRepository userRepository)
        {
            _authentication = authentication;
            _unitOfWork = unitOfWork;
            _userContext = userContext;
            _userRepository = userRepository;   
        }

        public async Task<Result<SuccessInfo, List<Error>>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var result =  await _authentication.DeleteAuthUserAsync(request.Id);

            if(result.IsError) return result;

            _userRepository.Remove(request.Id);

            await _unitOfWork.SaveAsync();

            return result;
        }
    }
}
