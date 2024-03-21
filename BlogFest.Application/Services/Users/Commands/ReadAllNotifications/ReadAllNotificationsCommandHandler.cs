using BlogFest.Application.Abstract;
using BlogFest.Domain.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogFest.Application.Services.Users.ReadAllNotifications
{
    public class ReadAllNotificationsCommandHandler : IRequestHandler<ReadAllNotificationsCommand>
    {
        private readonly IUserContext _userContext;
        private readonly IUserRepository _userRepository;
        public ReadAllNotificationsCommandHandler(IUserContext userContext, IUserRepository userRepository)
        {
            _userContext = userContext;
            _userRepository = userRepository;
        }
        public async Task Handle(ReadAllNotificationsCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByIdAsync(_userContext.CurrentUserId);

            user.ReadAllNotifications();
            await _userRepository.Update(user);
        }
    }
}
