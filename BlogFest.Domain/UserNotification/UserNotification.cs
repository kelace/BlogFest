using BlogFest.Domain.Base;
using BlogFest.Domain.NotificationUser.Events;

namespace BlogFest.Domain.NotificationUser
{
    public class UserNotification : AggregateRoot
    {
        private List<User> _users;
        public UserNotification(Guid id, List<User> users) : base(id) 
        {
            _users = users;
        }

        public Result<SuccessInfo, Error> NotifyUser(List<NewUserSettings> newSettings)
        {
            foreach (var item in newSettings)
            {
                var user = _users.Where(x => x.Id == item.Id).FirstOrDefault();
                var notifications = user.Notify(item.IsActive, item.IsAllowedToCreatePost, item.IsAllowedToComment);

                AddEvent(new UserHasBeenNotifiedEvent
                {
                    UserNotifications = notifications,
                    UserId = item.Id,
                } );
            }

            return new SuccessInfo
            {
                Id = Id,
                Message = "Settings have been changed successfully"
            };
        }
    }
}
