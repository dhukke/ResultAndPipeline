using System;
using System.Threading;
using System.Threading.Tasks;
using ExceptionDriven.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ExceptionDriven.PipelineBehaviors
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
