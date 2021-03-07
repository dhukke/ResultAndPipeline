using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace ResultPipeline.PipelineBehaviors
{
    public class LoggingPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<LoggingPipelineBehavior<TRequest, TResponse>> _logger;

        public LoggingPipelineBehavior(ILogger<LoggingPipelineBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(
            TRequest request,
            CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next
        )
        {
            _logger.LogInformation($"Handling Request {typeof(TRequest).Name} {request}");

            var myType = request.GetType();
            var props = new List<PropertyInfo>(myType.GetProperties());

            foreach (var prop in props)
            {
                var propValue = prop.GetValue(request, null);
                _logger.LogInformation("{Property} : {@Value}", prop.Name, propValue);
            }

            var response = await next();

            _logger.LogInformation($"Handled Response {typeof(TResponse).Name} {response}");

            return response;
        }
    }
}
