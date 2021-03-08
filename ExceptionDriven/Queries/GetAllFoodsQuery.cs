using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ExceptionDriven.Entities;
using ExceptionDriven.Models;
using MediatR;

namespace ExceptionDriven.Queries
{
    public class GetAllFoodsQuery : RequestWithUser, IRequest<IEnumerable<Food>>{}

    public class GetAllFoodsHandler : IRequestHandler<GetAllFoodsQuery, IEnumerable<Food>>
    {
        public GetAllFoodsHandler()
        {
        }

        public async Task<IEnumerable<Food>> Handle(
            GetAllFoodsQuery request,
            CancellationToken cancellationToken
        )
        {
            return new[] {
                new Food { Name = $"Burguer for {request.UserId}" },
                new Food { Name = $"Mango for {request.UserId}" },
            };
        }
    }
}
