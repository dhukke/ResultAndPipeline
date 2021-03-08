using System.Linq;
using ExceptionDriven.Models;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ResultPipeline.Filters
{
    public class ValidationFilter : IActionFilter, IOrderedFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            var iActionResult = context.Result;

            if (((ObjectResult) iActionResult).Value is not Result result) return;

            if (result.IsFailed)
            {
                context.Result = new ObjectResult(
                    result.Errors.Select(
                        x => new ErrorResponse("400", x.Message)
                    )
                )
                {
                    StatusCode = 400
                };
            }
        }

        public int Order { get; }
    }
}
