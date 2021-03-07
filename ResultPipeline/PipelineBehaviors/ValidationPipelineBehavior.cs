using System.Threading;
using System.Threading.Tasks;
using FluentResults;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ResultPipeline.PipelineBehaviors
{
    public class ValidationPipelineBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse>
        where TResponse : ResultBase, new()
    {
        private readonly IValidator<TRequest> _compositeValidator;

        private readonly ILogger<ValidationPipelineBehavior<TRequest, TResponse>> _logger;


        public ValidationPipelineBehavior(
            IValidator<TRequest> compositeValidator,
            ILogger<ValidationPipelineBehavior<TRequest, TResponse>> logger
        )
        {
            _compositeValidator = compositeValidator;
            _logger = logger;
        }

        public async Task<TResponse> Handle(
            TRequest request,
            CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next
        )
        {
            _logger.LogInformation($"Validanting Request {typeof(TRequest).Name} {request}");

            var result = await _compositeValidator.ValidateAsync(request, cancellationToken);

            if (result.IsValid) return await next();

            var error = new Error();

            foreach (var validationFailure in result.Errors)
            {
                _logger.LogInformation($"Validation message: {validationFailure}");
                error.Reasons.Add(new Error(validationFailure.ErrorMessage));
            }
            // "Result.Fail<TResponse>(error);" should be "Result.Fail(error) as TResponse;"
            // This caused a build error as it could not implicitly cast this to TResponse,
            // I tried to solve this by adding "as TResponse" but this in turn caused the return value to always be null;
            // The solution was to remove the "<TResponse>" and then it worked!
            return Result.Fail(error) as TResponse;

        }
    }
}
