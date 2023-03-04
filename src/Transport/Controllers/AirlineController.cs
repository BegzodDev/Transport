﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}
