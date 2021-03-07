using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ResultPipeline.Entities;
using ResultPipeline.Models;

namespace ResultPipeline.Queries
{
    public class GetAllFoodsQuery : RequestWithUser, IRequest<IEnumerable<Food>>{}

    public class GetAllCarsQueryHandler : IRequestHandler<GetAllFoodsQuery, IEnumerable<Food>>
    {
        public async Task<IEnumerable<Food>> Handle(
            GetAllFoodsQuery request,
            CancellationToken cancellationToken
        )
        {
            // some buisness logic

            return new[] {
                new Food { Name = $"Burito for {request.UserId}" },
                new Food { Name = $"Salad {request.UserId}" },
            };
        }
    }
}
