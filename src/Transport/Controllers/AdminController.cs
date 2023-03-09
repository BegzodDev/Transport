using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Transport.Application.UseCase.Admin.Commands.Airlines;
using Transport.Application.UseCase.Admin.Queries.AirLineQuery;

namespace Transport.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : Controller
    {
        private readonly IMediator _mediator;
        public AdminController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize(Policy = "AdminActions")]
        public async Task<IActionResult> Create(CreateAirlineCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }

        [HttpPut]
        [Authorize(Policy = "AdminActions")]
        public async Task<IActionResult> Update([FromForm] UpdateAirlineCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }


        [HttpDelete]
        [Authorize(Policy = "AdminActions")]
        public async Task<IActionResult> Delete([FromForm] DeleteAirlineCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        //[HttpGet("Id")]
        //[Authorize(Policy = "AdminActions")]
        //public async Task<IActionResult> Get([FromForm] GetAirLineQuery query)
        //{
        //    var response = await _mediator.Send(query);
        //    return Ok(response);
        //}

        //[HttpGet]
        //[Authorize(Policy = "AdminActions")]
        //public async Task<IActionResult> GetAll([FromForm] GetAllAirLineQuery query)
        //{
        //    var response = await _mediator.Send(query);
        //    return Ok(response);

        //    //var response = await _mediator.Send(new GetAllAirLineQuery());

        //    //if (response.Count == 0)
        //    //{
        //    //    return Ok("");
        //    //}

        //    //return Ok(response);
        //}
    }
}