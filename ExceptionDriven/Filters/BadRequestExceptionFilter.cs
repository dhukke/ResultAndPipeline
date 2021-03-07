using System.Linq;
using ExceptionDriven.Commands;
using ExceptionDriven.Models;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ExceptionDriven.Filters
{
    public class BadRequestExceptionFilter : IActionFilter, IOrderedFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            context.Result = context.Exception switch
            {
                BadRequestException exception => new ObjectResult(exception.Error) {StatusCode = 400},
                ValidationException validationException => new ObjectResult(
                    validationException.Errors.Select(x => new Error(x.ErrorCode, x.ErrorMessage))) {StatusCode = 400},
                _ => context.Result
            };

            context.ExceptionHandled = true;
        }

        public int Order { get; }
    }
}
