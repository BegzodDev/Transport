using Amazon.Auth.AccessControlPolicy;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;
using Transport.Application.UseCase.Admin.Commands.Airlines;
using Transport.Application.UseCase.Admin.Commands.Trains;

namespace Transport.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainController : Controller
    {
        private readonly IMediator _mediator;
        public TrainController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Rais")]
        [Authorize(Policy ="AdminActions")]
        public async Task<IActionResult> Create(UpdateTrainCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut("Rais")]
        [Authorize(Policy = "AdminActions")]
        public async Task<IActionResult> Update(/*[FromForm]*/ CreateTrainCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }
        [HttpDelete("Rais")]
        [Authorize(Policy ="AdminActions")]
        public async Task<IActionResult> Delete(DeleteTrainCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
