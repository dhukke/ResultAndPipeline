using System;
using System.Threading;
using System.Threading.Tasks;
using ExceptionDriven.Models;
using ExceptionDriven.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ExceptionDriven.Commands
{
    public class CreateFoodCommand : IRequest
    {
        public CreateFoodCommand(RequestCreateFood requestCreateFood)
        {
            Name = requestCreateFood.Name;
        }

        public string Name { get; set; }
    }

    public class CreateFoodCommandHandler : IRequestHandler<CreateFoodCommand>
    {
        public Task<Unit> Handle(CreateFoodCommand request, CancellationToken cancellationToken)
        {
            // if (false)
            // {
            //     return Task.FromResult(Response.Fail<Food>("already exists"));
            // }

            throw new BadRequestException(Errors.FoodAlreadyExistError);

            return Unit.Task;
        }
    }

    public class BadRequestException : Exception
    {
        public BadRequestException() : base() { }
        public BadRequestException(string message) : base(message) { }
        public BadRequestException(string message, Exception inner) : base(message, inner) { }

        public Error Error { get; set; }
        public BadRequestException(Error foodAlreadyExistError) : base(foodAlreadyExistError.ErrorMessage)
        {
            Error = foodAlreadyExistError;
        }
    }
}
