using BlogFest.Application.Behaviors.Abstract;
using BlogFest.Application.Services.Abstract;
using BlogFest.Domain.Base;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace BlogFest.Application.Behaviors
{
    public class RefreshCacheBehavior<TRequest, TResponse> : 
                IPipelineBehavior<TRequest, TResponse> where TRequest : ICacheRefreshable, IApplicationCommand, 
                IRequest<Result<SuccessInfo, Error>> where TResponse : Result<SuccessInfo, Error>
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IMediator _mediator;
        public RefreshCacheBehavior(IMemoryCache memoryCache, IMediator mediator)
        {
            _memoryCache = memoryCache;
            _mediator = mediator;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var result = await next();
            var respons = (Result<SuccessInfo, Error>)result;
            var req = (ICacheRefreshable)request;

            if (respons.IsError) return result;

            var key = req.RefreashbleKey + respons.Value.Slug;

            if (_memoryCache.TryGetValue(key, out var memory))
            {
                if(memory != null) _memoryCache.Remove(key);
            }

            return result;
        }
    }
}
