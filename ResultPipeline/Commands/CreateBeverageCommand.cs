using System.Threading;
using System.Threading.Tasks;
using FluentResults;
using MediatR;
using ResultPipeline.Requests;

namespace ResultPipeline.Commands
{
    public class CreateBeverageCommand : IRequest<Result>
    {
        public CreateBeverageCommand(RequestCreateBeverage requestCreateBeverage)
        {
            Name = requestCreateBeverage.Name;
        }

        public string Name { get; private set; }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}";
        }
    }

    public class CreateBeverageCommandHandler : IRequestHandler<CreateBeverageCommand, Result>
    {
        public Task<Result> Handle(CreateBeverageCommand request, CancellationToken cancellationToken)
        {
            if (request.Name == "fail")
            {
                return Task.FromResult(Result.Fail("should fail"));
            }

            return Task.FromResult(Result.Ok());
        }
    }
}
