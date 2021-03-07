using System.Collections.Generic;
using System.Threading.Tasks;
using ExceptionDriven.Commands;
using ExceptionDriven.Entities;
using ExceptionDriven.Queries;
using ExceptionDriven.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExceptionDriven.Controllers
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
        public async Task<ActionResult<IEnumerable<Food>>> GetAllFoods()
            => Ok(await _mediator.Send(new GetAllFoodsQuery()));

        [HttpPost]
        public async Task<IActionResult> CreateFood([FromBody] RequestCreateFood request)
            => Ok(await _mediator.Send(new CreateFoodCommand(request)));
    }
}
