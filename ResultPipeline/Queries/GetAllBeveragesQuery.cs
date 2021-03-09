using System;
using System.Threading;
using System.Threading.Tasks;
using FluentResults;
using MediatR;
using ResultPipeline.Entities;
using ResultPipeline.Models;
using ResultPipeline.Responses;

namespace ResultPipeline.Queries
{
    public class GetAllBeveragesQuery : RequestWithUser, IRequest<Result<GetAllBeveragesResponse>>
    {
        public GetAllBeveragesQuery(string fail)
        {
            Fail = fail;
        }

        public string Fail { get; }
    }

    public class GetAllBeveragesHandler : IRequestHandler<GetAllBeveragesQuery, Result<GetAllBeveragesResponse>>
    {
        public  Task<Result<GetAllBeveragesResponse>> Handle(
            GetAllBeveragesQuery request,
            CancellationToken cancellationToken
        )
        {
            if (request.Fail == "fail")
            {
                return Task.FromResult(
                    Result.Fail<GetAllBeveragesResponse>("Code22:ShouldFailToGet")
                );
            }

            return Task.FromResult(
                Result.Ok(GetBeverages(request.UserId))
            );
        }

        private static GetAllBeveragesResponse GetBeverages(Guid requestUserId)
        {
            return new()
            {
                Beverages = new[] {
                    new Beverage { Name = $"Beer for {requestUserId}" },
                    new Beverage { Name = $"Water for {requestUserId}" },
                }
            };
        }
    }
}
