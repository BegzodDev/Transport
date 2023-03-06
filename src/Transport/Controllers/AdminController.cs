using Amazon.Auth.AccessControlPolicy;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Transport.Application.UseCase.Admin.Commands.Airlines;

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

        [HttpPost("Admin")]
        [Authorize(Policy = "AdminActions")]
        public async Task<IActionResult> Create(CreateAirlineCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok();
        }

        [HttpPut("Query")]
        [Authorize(Policy = "AdminActions")]
        public async Task<IActionResult> Update([FromForm] UpdateAirlineCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }


        [HttpDelete("Query")]
        [Authorize(Policy = "AdminActions")]
        public async Task<IActionResult> Delete([FromForm] DeleteAirlineCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

    }
}
