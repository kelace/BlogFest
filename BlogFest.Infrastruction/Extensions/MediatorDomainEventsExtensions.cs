using MediatR;

namespace BlogFest.Data.Extensions
{
    public static class MediatorDomainEventsExtensions
    {
        public static async Task ApplyDomainEvents(this IMediator mediator, IDomainEventStorage domainEventService)
        {
            var events = domainEventService.GetEvents();
            domainEventService.ClearEvents();

            foreach (var @event in events)
            {
                await mediator.Publish(@event);
            }
        }
    }
}
