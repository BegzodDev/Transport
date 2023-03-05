using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Transport.Application.UseCase.Admin.Commands.Airlines;
using Transport.Application.UseCase.User.Commands;
using Transport.Application.UseCase.User.Queries;

namespace Transport.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirlineController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AirlineController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateAirlineTickerCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> Delete(DeleteTicketAirlineCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Update(UpdateTicketAirlineCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Update(GetTicketQuery query)
        {
            var response = await _mediator.Send(query);
            return Ok(response);
        }


        [HttpPost("Rais")]
        [Authorize(Policy = "AdminActions")]
        public async Task<IActionResult> Create(/*[FromForm]*/ CreateAirlineCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpPut("Rais")]
        [Authorize(Policy = "AdminActions")]
        public async Task<IActionResult> Update([FromForm] UpdateAirlineCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }


        [HttpDelete("Rais")]
        [Authorize(Policy = "AdminActions")]
        public async Task<IActionResult> Delete([FromForm] DeleteAirlineCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

    }
}
