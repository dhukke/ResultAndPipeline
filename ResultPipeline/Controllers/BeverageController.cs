using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ResultPipeline.Commands;
using ResultPipeline.Entities;
using ResultPipeline.Queries;
using ResultPipeline.Requests;

namespace ResultPipeline.Controllers
{
    [ApiController]
    [Route("beverages")]
    public class BeverageController: Controller
    {
        private readonly IMediator _mediator;

        public BeverageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public Task<IEnumerable<Beverage>> GetAllBeverages()
            => _mediator.Send(new GetAllBeveragesQuery());

        [HttpPost]
        public Task<Result> CreateBeverage([FromBody] RequestCreateBeverage request)
            => _mediator.Send(new CreateBeverageCommand(request));
    }
}
