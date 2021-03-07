using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ResultPipeline.Commands;
using ResultPipeline.Entities;
using ResultPipeline.Queries;
using ResultPipeline.Requests;

namespace ResultPipeline.Controllers
{
    [ApiController]
    [Route("foods")]
    public class FoodController: Controller
    {
        private readonly IMediator _mediator;

        public FoodController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public Task<IEnumerable<Food>> GetAllFoods()
        {
            return _mediator.Send(new GetAllFoodsQuery());
        }

        [HttpPost]
        public Task<Response<Food>> CreateFood([FromBody] RequestCreateFood request)
        {
            return _mediator.Send(new CreateFoodCommand(request));
        }

        // [HttpPost]
        // public async Task<IActionResult> CreateFood([FromBody] RequestCreateFood request)
        // {
        //     var response = await _mediator.Send(new CreateFoodCommand(request));
        //
        //     if (response.Errors.Any())
        //     {
        //         return BadRequest(response.Errors);
        //     }
        //     return Ok(response.Result);
        // }
    }
}
