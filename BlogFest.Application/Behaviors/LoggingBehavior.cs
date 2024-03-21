using MediatR;
using Microsoft.Extensions.Logging;

namespace BlogFest.Application.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger _logger;
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Begin command" + nameof(TRequest));
            var result =  await next();
            _logger.LogInformation("End command" + nameof(TRequest));
            return result;
        }
    }
}
