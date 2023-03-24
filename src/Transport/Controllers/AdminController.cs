using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Transport.Application.DTOs;
using Transport.Application.UseCase.Admin.Commands.Airlines;
using Transport.Application.UseCase.Admin.Commands.Busses;
using Transport.Application.UseCase.Admin.Commands.Trains;
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
        [HttpPost("AirLine")]
        [Authorize(Policy = "AdminActions")]
        public async Task<IActionResult> Create(AirLineViewModel viewModel)
        {
            var response = await _mediator.Send(new CreateAirlineCommand()
            {
                Flight_From = viewModel.FlightFrom,
                Flight_To = viewModel.FlightTo,
                Price = viewModel.Price,
                Date = viewModel.Date,
                CountBusinessClassPlace = viewModel.CountBusinessClassPlace,
                CountEconomyClassPlace = viewModel.CountEconomyClassPlace,
                CountVIPClassPlace = viewModel.CountVIPClassPlace,
            });
            return Ok(response);
        }
        [HttpPut("AirLine")]
        [Authorize(Policy = "AdminActions")]
        public async Task<IActionResult> Update([FromForm] UpdateAirlineCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
        [HttpDelete("AirLine")]
        [Authorize(Policy = "AdminActions")]
        public async Task<IActionResult> Delete([FromForm] DeleteAirlineCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
        [HttpGet("Id")]
        [Authorize(Policy = "AdminActions")]
        public async Task<IActionResult> Get(int page)
        {
            var response = await _mediator.Send(new GetAirLineQuery(page));
            return Ok(response);
        }

        [HttpGet("AirLine")]
        [Authorize(Policy = "AdminActions")]
        public async Task<IActionResult> GetAll()
        {
            var manufacturers = await _mediator.Send(new GetAllAirLineQuery());

            if (manufacturers.Count == 0)
            {
                return Ok("");
            }
            return Ok(manufacturers);
        }


        // Buss
        [HttpPost("Buss")]
        [Authorize(Policy = "AdminActions")]
        public async Task<IActionResult> CreateBus(CreateBussCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }
        [HttpPut("Buss")]
        [Authorize(Policy = "AdminActions")]
        public async Task<IActionResult> UpdateBus([FromForm] UpdateBussCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
        [HttpDelete("Buss")]
        [Authorize(Policy = "AdminActions")]
        public async Task<IActionResult> DeleteBus([FromForm] DeleteBussCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }


        // Trains
        [HttpPost("Train")]
        [Authorize(Policy = "AdminActions")]
        public async Task<IActionResult> CreateTrain(CreateTrainCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
        [HttpPut("Train")]
        [Authorize(Policy = "AdminActions")]
        public async Task<IActionResult> UpdateTrain([FromForm] UpdateTrainCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
        [HttpDelete("Train")]
        [Authorize(Policy = "AdminActions")]
        public async Task<IActionResult> DeleteTrain([FromForm] DeleteTrainCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}