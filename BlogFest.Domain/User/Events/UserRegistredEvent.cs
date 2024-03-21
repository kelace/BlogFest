using BlogFest.Domain.Base;

namespace BlogFest.Web.Domain.Users.Events
{
    public class UserRegistredEvent : DomainEvent
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
