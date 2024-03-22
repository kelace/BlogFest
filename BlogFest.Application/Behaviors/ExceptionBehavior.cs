﻿using MediatR;
using Microsoft.Extensions.Logging;


namespace BlogFest.Application.Behaviors
{
    public class ExceptionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
		private readonly ILogger _logger;
        public ExceptionBehavior(ILogger logger)
        {
            _logger = logger;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
			try
			{
				return await next();
			}
			catch (Exception ex)
			{
                _logger.LogError(ex.Message);
                throw;
			}
        }
    }
}