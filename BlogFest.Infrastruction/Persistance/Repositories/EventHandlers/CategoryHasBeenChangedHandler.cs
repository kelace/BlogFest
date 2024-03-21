using MediatR;
using BlogFest.Domain.Administration.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogFest.Infrastruction.Persistance.Repositories.EventHandlers
{
    public class CategoryHasBeenChangedHandler : IRequestHandler<DomainEventAdapter<CategoryHasBeenCreated>>
    {
        public Task Handle(DomainEventAdapter<CategoryHasBeenCreated> request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
