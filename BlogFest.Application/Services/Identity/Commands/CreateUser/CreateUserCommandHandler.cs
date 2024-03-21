using BlogFest.Application.Abstract;
using BlogFest.Application.Shared;
using BlogFest.Domain.Base;
using BlogFest.Domain.Users;
using MediatR;

namespace BlogFest.Application.Services.Identity.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result<SuccessInfo, List<Error>>>
    {
        private readonly IApplicationAuthentication _authService;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateUserCommandHandler(IApplicationAuthentication authService, IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _authService = authService;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<SuccessInfo, List<Error>>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _authService.RegisterUser(request.RegisterUser);

            if (!result.IsSuccess) return result.Error;

            var id = result.Value.Id;

            var user = new User(id, request.RegisterUser.Name);

            await _userRepository.Add(user);
            await _unitOfWork.SaveAsync();

            return result;
        }
    }
}
