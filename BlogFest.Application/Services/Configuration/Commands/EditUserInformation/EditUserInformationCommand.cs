using BlogFest.Application.Services.Abstract;
using BlogFest.Domain.Base;
using MediatR;


namespace BlogFest.Application.Services.Configuration.Commands.EditUserInformation
{
    public class EditUserInformationCommand : IRequest<Result<Guid, Error>>, IApplicationCommand
    {
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid? PhotoId { get; set; }
        public Guid UserId { get; set; }
        public string Bio { get; set; }
    }
}
