namespace BlogFest.Infrastructure.Persistance.Repositories.EventHandlers
{
    public interface IDataEventHandler<TEntity, TDomain>
    {
        public Task Handle(TDomain @event);
    }
}
