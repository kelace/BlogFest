using BlogFest.Application.Services.Identity.DTOs;
using BlogFest.Domain.Base;
using MediatR;

namespace BlogFest.Application.Services.Identity.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<Result<SuccessInfo, List<Error>>>
    {
        public RegisterUserDTO RegisterUser { get; set; }
    }
}
