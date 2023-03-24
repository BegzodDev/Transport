using MediatR;
using Microsoft.AspNetCore.Mvc;
using Transport.Application.UseCase.User.Commands;
using Transport.Application.UseCase.User.Queries;

namespace Transport.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BusController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateBussTicketCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateBusTicketCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteBusTicketCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> Get(GetBusTicketQuery query)
        {
            await _mediator.Send(query);
            return Ok();
        }
    }
}