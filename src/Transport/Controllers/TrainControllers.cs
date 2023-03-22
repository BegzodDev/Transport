using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Transport.Application.UseCase.User.Commands;
using Transport.Application.UseCase.User.Commands.Trains;
using Transport.Application.UseCase.User.Queries;

namespace Transport.Api.Controllers
{
    public class TrainControllers : ControllerBase
    {
        private readonly IMediator _mediator;

        public TrainControllers(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize]

        public async Task<IActionResult> Create(CreateTrainTicketCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPost]
        [Authorize]

        public async Task<IActionResult> Delete(DeleteTrainTicketCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPost]
        [Authorize]

        public async Task<IActionResult> Update(UpdateTrainTicketCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPost]
        [Authorize]

        public async Task<IActionResult> Update(GetTrainTicketQuery query)
        {
           var response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpDelete("Rais")]
        [Authorize(Policy = "AdminActions")]

        public async Task<IActionResult> Create(CreateTrainTicketCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete("Rais")]
        [Authorize(Policy = "AdminActions")]

        public async Task<IActionResult> Delete([FromForm] DeleteTrainTicketCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete("Rais")]
        [Authorize(Policy = "AdminActions")]

        public async Task<IActionResult> Update([FromForm] UpdateTrainTicketCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}
