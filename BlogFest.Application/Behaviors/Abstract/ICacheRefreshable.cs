using MediatR;

namespace BlogFest.Application.Behaviors.Abstract
{
    public interface ICacheRefreshable
    {
        public string RefreashbleKey { get; }
    }
}
