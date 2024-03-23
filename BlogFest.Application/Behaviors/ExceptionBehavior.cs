﻿using MediatR;
using Microsoft.Extensions.Logging;


namespace BlogFest.Application.Behaviors
{
    public class ExceptionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
		private readonly ILogger<ExceptionBehavior<TRequest, TResponse>> _logger;
        public ExceptionBehavior(ILogger<ExceptionBehavior<TRequest, TResponse>> logger)
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
