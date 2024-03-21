using BlogFest.Domain.Administration.Events;
using BlogFest.Domain.NotificationUser;
using MediatR;

namespace BlogFest.Application.Services.Users.EventsHandler
{
    public class NotifyUserEventHandler : INotificationHandler<UserSettingsHasBeenEditedEvent>
    {
        private readonly IUserNotificationRepository _userRepository;
        public NotifyUserEventHandler(IUserNotificationRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task Handle(UserSettingsHasBeenEditedEvent request, CancellationToken cancellationToken)
        {
            var ids = request.NewUserSettings.Select(x => x.UserId).ToList();
            var user = await _userRepository.GetByIdAsync(request.ManagerId, ids);
            var newSettings = request.NewUserSettings.Select(x => new NewUserSettings
            {
                Id = x.UserId,
                IsActive = x.IsActive,
                IsAllowedToCreatePost = x.IsAllowedToCreateThread,
                IsAllowedToComment = x.IsAllowedToComment,
            }).ToList();

			user.NotifyUser(newSettings);

			await _userRepository.UpdateAsync(user);

		}
    }
}
