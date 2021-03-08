using System.Threading.Tasks;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ResultPipeline.Commands;
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
        public async Task<IActionResult> GetAllBeverages()
        {
            var result = await _mediator.Send(new GetAllBeveragesQuery());

            if (result.IsFailed)
            {
                return BadRequest(result.ToResult());
            }

            return Ok(result.Value);

        }

        [HttpPost]
        public async Task<IActionResult> CreateBeverage([FromBody] RequestCreateBeverage request)
            =>  Ok(await _mediator.Send(new CreateBeverageCommand(request)));
    }
}
