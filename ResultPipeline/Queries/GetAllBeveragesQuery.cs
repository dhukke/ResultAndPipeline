using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FluentResults;
using MediatR;
using ResultPipeline.Entities;
using ResultPipeline.Responses;

namespace ResultPipeline.Queries
{
    public class GetAllBeveragesQuery : IRequest<Result<GetAllBeveragesResponse>>{}

    public class GetAllBeveragesHandler : IRequestHandler<GetAllBeveragesQuery, Result<GetAllBeveragesResponse>>
    {
        public  Task<Result<GetAllBeveragesResponse>> Handle(
            GetAllBeveragesQuery request,
            CancellationToken cancellationToken
        )
        {
            // return Task.FromResult(
            //     Result.Fail<GetAllBeveragesResponse>("ErrorCode22")
            // );

            return Task.FromResult(
                Result.Ok(GetBeverages())
            );
        }

        private static GetAllBeveragesResponse GetBeverages()
        {
            return new GetAllBeveragesResponse
            {
                Beverages = new List<Beverage>
                {
                    new Beverage {Name = "Burguer"},
                    new Beverage {Name = "Mango"},
                }
            };
        }
    }
}
