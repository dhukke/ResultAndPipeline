using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using ResultPipeline.Models;

namespace ResultPipeline.PipelineBehaviors
{
    public class UserAppendPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<UserAppendPipelineBehavior<TRequest, TResponse>> _logger;

        public UserAppendPipelineBehavior(ILogger<UserAppendPipelineBehavior<TRequest, TResponse>> logger)
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

            if (request is RequestWithUser requestWithUser)
            {
                _logger.LogInformation("Appending User");
                requestWithUser.UserId = Guid.NewGuid();
            }

            var response = await next();

            return response;
        }
    }
}
