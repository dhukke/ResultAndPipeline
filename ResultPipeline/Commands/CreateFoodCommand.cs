using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ResultPipeline.Controllers;
using ResultPipeline.Entities;
using ResultPipeline.Requests;

namespace ResultPipeline.Commands
{
    public class CreateFoodCommand : IRequest<Response<Food>>
    {
        public CreateFoodCommand(RequestCreateFood requestCreateFood)
        {
            Name = requestCreateFood.Name;
        }

        public string Name { get; set; }

    }

    public class CreateFoodCommandHandler : IRequestHandler<CreateFoodCommand, Response<Food>>
    {
        public Task<Response<Food>> Handle(CreateFoodCommand request, CancellationToken cancellationToken)
        {
            // if (false)
            // {
            //     return Task.FromResult(Response.Fail<Food>("already exists"));
            // }

            return Task.FromResult(Response.Ok(new Food { Name = "Bacon" }, "Car Created"));
        }
    }
}
