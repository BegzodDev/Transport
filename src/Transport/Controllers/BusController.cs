using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Transport.Application.UseCase.Admin.Commands.Busses;

namespace Transport.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BussController : Controller
    {
        private readonly IMediator _mediator;
        public BussController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Rais")]
        [Authorize(Policy = "AdminActions")]
        public async Task<IActionResult> Create(CreateBussCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut("Rais")]
        [Authorize(Policy = "AdminActions")]
        public async Task<IActionResult> Update(/*[FromForm]*/ UpdateBussCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }
        [HttpDelete("Rais")]
        [Authorize(Policy = "AdminActions")]
        public async Task<IActionResult> Delete(DeleteBussCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
