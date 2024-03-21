using BlogFest.Domain.Base;

namespace BlogFest.Domain.User.Events
{
    public class ReadAllUserNotificationsEvent : DomainEvent
    {
        public Guid UserId { get; set; }
    }
}
