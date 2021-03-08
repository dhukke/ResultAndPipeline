using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentResults;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ResultPipeline.PipelineBehaviors
{
    public class ValidationPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TResponse : ResultBase, new()
    {

        private readonly ILogger<ValidationPipelineBehavior<TRequest, TResponse>> _logger;
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationPipelineBehavior(

            ILogger<ValidationPipelineBehavior<TRequest, TResponse>> logger,IEnumerable<IValidator<TRequest>> validators
            )
        {
            _validators = validators;

            _logger = logger;
        }

        public async Task<TResponse> Handle(
            TRequest request,
            CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next
        )
        {
            _logger.LogInformation($"Validanting Request {typeof(TRequest).Name} {request}");

            if (!_validators.Any()) return await next();

            var context = new ValidationContext<TRequest>(request);

            var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
            var errors  = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

            if(!errors.Any())  return await next();

            var error = new List<ResultBase>();

            foreach (var validationFailure in errors)
            {
                _logger.LogInformation($"Validation message: {validationFailure}");
                error.Add(Result.Fail((validationFailure.ErrorMessage)));
            }

            return Result.Merge(error.ToArray()) as TResponse;

        }
    }
}
