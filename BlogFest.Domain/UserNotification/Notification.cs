using BlogFest.Domain.Base;

namespace BlogFest.Domain.NotificationUser
{
    public class Notification : Entity
    {
        public string Message { get; private set; }
        public Notification(Guid id, string message) : base(id)
        {
            Message = message;
        }
    }
}
