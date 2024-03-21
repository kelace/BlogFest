using BlogFest.Domain.Base;

namespace BlogFest.Data
{
    public interface IDomainEventStorage
    {
        public void AddEvent(DomainEvent domain);
        public void AddEvent(List<DomainEvent> domains);
        public void ClearEvents();
        public List<DomainEvent> GetEvents();
    }
}