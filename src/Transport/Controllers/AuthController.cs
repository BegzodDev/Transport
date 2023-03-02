using MediatR;
using Microsoft.AspNetCore.Mvc;
using Transport.Application.UseCase.Auth.Commands;
using Transport.Application.UseCase.User.Commands;

namespace Transport.Api.Controllers
{
    public class AuthController : Controller
    {
        private readonly IMediator _mediator;
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginCommand command)
        {
            var token = await _mediator.Send(command);

            return Ok(token);
        }

        //[HttpPost("Customer/Register")]
        //public async Task<IActionResult> RegisterAsCustomer(CustomerRegisterCommand command)
        //{
        //    await _mediator.Send(command);

        //    return Ok();
        //}

        [HttpPost("UserRegister")]
        public async Task<IActionResult> RegisterAsUser([FromForm] RegisterUserCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }
    }
}
