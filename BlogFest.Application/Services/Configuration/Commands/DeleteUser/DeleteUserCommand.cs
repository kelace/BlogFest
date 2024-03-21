using BlogFest.Application.Services.Abstract;
using BlogFest.Domain.Base;
using MediatR;

namespace BlogFest.Application.Services.Configuration.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest<Result<SuccessInfo, List<Error>>>, IApplicationCommand
    {
        public Guid Id { get; set; }
    }
}
