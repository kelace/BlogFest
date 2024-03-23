using MediatR;
using Microsoft.Extensions.Logging;

namespace BlogFest.Application.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;
        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Begin command" + nameof(TRequest));
            var result =  await next();
            _logger.LogInformation("End command" + nameof(TRequest));
            return result;
        }
    }
}
