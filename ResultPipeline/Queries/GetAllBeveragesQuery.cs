using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ResultPipeline.Entities;

namespace ResultPipeline.Queries
{
    public class GetAllBeveragesQuery : IRequest<IEnumerable<Beverage>>{}

    public class GetAllBeveragesQueryHandler : IRequestHandler<GetAllBeveragesQuery, IEnumerable<Beverage>>
    {
        // do dependency injection here if need
        public GetAllBeveragesQueryHandler()
        {

        }

        public async Task<IEnumerable<Beverage>> Handle(
            GetAllBeveragesQuery request,
            CancellationToken cancellationToken
        )
        {
            // some buisness logic

            return new[] {
                new Beverage { Name = "Burguer" },
                new Beverage { Name = "Mango" },
            };
        }
    }
}
