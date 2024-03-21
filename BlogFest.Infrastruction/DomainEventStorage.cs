using BlogFest.Domain.Base;

namespace BlogFest.Data
{
    public class DomainEventStorage : IDomainEventStorage
    {
        List<DomainEvent> _domainEvents = new List<DomainEvent>();
        Object _lock = new object();
        public void AddEvent(DomainEvent domain)
        {
            if (_domainEvents == null) throw new ArgumentNullException(nameof(domain));

            lock (_lock)
            {
                _domainEvents.Add(domain);
            }
        }

        public List<DomainEvent> GetEvents()
        {
            return _domainEvents.ToList();
        }

        public void ClearEvents()
        {
            lock (_lock)
            {
                _domainEvents = new List<DomainEvent>();
            }     
        }

        public void AddEvent(List<DomainEvent> domains)
        {
            if (_domainEvents == null) throw new ArgumentNullException(nameof(domains));

            lock (_lock)
            {
                _domainEvents.AddRange(domains);
            }
        }
    }
}
