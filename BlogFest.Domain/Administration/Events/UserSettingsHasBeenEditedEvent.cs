using BlogFest.Domain.Administration;
using BlogFest.Domain.Base;

namespace BlogFest.Domain.Administration.Events
{
    public class UserSettingsHasBeenEditedEvent : DomainEvent
    {
        public Guid ManagerId { get; set; }
        public List<UserSettings> NewUserSettings { get; set; }
    }
}
