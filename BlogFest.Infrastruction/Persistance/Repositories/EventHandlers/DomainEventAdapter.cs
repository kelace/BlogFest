using MediatR;
using BlogFest.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogFest.Infrastruction.Persistance.Repositories.EventHandlers
{
    public class DomainEventAdapter<TDomainEvent> : IRequest
    {
        private readonly TDomainEvent _event;
        public DomainEventAdapter(TDomainEvent @event)
        {
            _event = @event;
        }
    }
}
