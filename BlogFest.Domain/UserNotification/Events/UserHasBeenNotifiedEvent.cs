using BlogFest.Domain.Base;
using BlogFest.Domain.NotificationUser;

namespace BlogFest.Domain.NotificationUser.Events
{
	public class UserHasBeenNotifiedEvent : DomainEvent
	{
		public List<Notification> UserNotifications { get; set; } = new List<Notification>();
		public Guid UserId { get; set; }
	}
}
