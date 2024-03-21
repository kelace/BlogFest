using BlogFest.Application.Behaviors.Abstract;
using BlogFest.Application.Users.Queries.GetUserInfo;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace BlogFest.Application.Behaviors
{
    public class CachingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : ICacheable
    {
        private readonly IMemoryCache _memoryCache;
        public CachingBehavior(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {

            TResponse response;
            if(_memoryCache.TryGetValue(request.Key, out response))
            {
                return response;
            }

            response = await next();
            _memoryCache.Set(request.Key, response);
            return response;
        }
    }
}
