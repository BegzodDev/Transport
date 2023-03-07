using MediatR;
using Microsoft.AspNetCore.Mvc;
using Transport.Application.UseCase.User.Commands;

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
    }
}
