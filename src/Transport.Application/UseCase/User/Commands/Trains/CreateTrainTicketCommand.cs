using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Transport.Application.Abstractions;
using Transport.Application.Exceptions;
using Transport.Domain.Entities;
using Transport.Domain.Enums;

namespace Transport.Application.UseCase.User.Commands
{
    public class CreateTrainTicketCommand : ICommand<Unit>
    {
        [Required]
        public string? PasportSeries { get; set; }
        
        [Required]
        public DateTime Date { get; set; }
        
        [Required]
        public string? From { get; set; }
        
        [Required]
        public string? For { get; set; }
        
        [Required]
        public int Place { get; set; }
        
        [Required]
        public Status Status { get; set; }

    }

    public class CreateTrainTicketCommandHandler : ICommandHandler<CreateTrainTicketCommand, Unit>
    {
        //Interfaces
        private readonly IApplicationDbContext _context;
        private readonly IGovermentService _govermentService;
        private readonly ISecurityService _securityService;
        private readonly IEconomyService _economyService;
        private readonly ICurrentUserService _currentUserService;
        private readonly IDistributedCache _distrubuteCache;

        //Constructor

        public CreateTrainTicketCommandHandler(IApplicationDbContext context,
                                                IGovermentService govermentService,
                                                ISecurityService securityService,
                                                IEconomyService economyService,
                                                ICurrentUserService currentUserService,
                                                IDistributedCache distributedCache)
        {
            _securityService = securityService;
            _context = context;
            _govermentService = govermentService;
            _economyService = economyService;
            _currentUserService = currentUserService;
            _distrubuteCache = distributedCache;
        }

        public async Task<Unit> Handle(CreateTrainTicketCommand command, CancellationToken cancellationToken)
        {
            if (!_govermentService.Check(command.PasportSeries!))
            {
                throw new Exception("Pasport series is don't have in our base");
            }
            _securityService.CheckSecure(command.PasportSeries!);
            var reys = _context.airlines.FirstOrDefault(x => x.Flight_From.ToLower() == command.From.ToLower() &&
                                                        x.Flight_For.ToLower() == command.For.ToLower() &&
                                                        x.Date.Year == command.Date.Year &&
                                                        x.Date.Month == command.Date.Month &&
                                                        x.Date.Day == command.Date.Day);

            if (reys == null)
            {
                throw new TrainNotFoundException();
            }
            if(command.Status == Status.Econom)
            {
                foreach (var places in _context.placeTrains)
                {
                    if (places.Place_in_Ticket == command.Place && places.Status == Status.Econom)
                    {
                        throw new Exception("This place is busy");
                    }
                    continue;
                }
            }
            if(command.Status == Status.Buiseness)
            {
                foreach (var places in _context.placeTrains)
                {
                    if (places.Place_in_Ticket == command.Place && places.Status == Status.Buiseness)
                    {
                        throw new Exception("This place is busy");
                    }
                    continue;
                }
            }
            if (command.Status == Status.VIP)
            {
                foreach (var places in _context.placeTrains)
                {
                    if (places.Place_in_Ticket == command.Place && places.Status == Status.VIP)
                    {
                        throw new Exception("This place is busy");
                    }
                    continue;
                }
            }
            var place = new PlaceAirline
            {
                Status = command.Status,
                Place_in_Ticket = command.Place,
                AirlineId = reys.Id
            };

            var user = _context.users.FirstOrDefault(x => x.UserName == command.From);

            var tickets = new TicketAirline();

            if(!_economyService.PaymentCheck(command.PasportSeries!, (double)reys.Price))
            {
                throw new Exception("Payment si valid");
            }
            else if(command.Status == Status.Econom)
            {
                if(_economyService.PaymentCheck(command.PasportSeries, (double)reys.Price))
                {
                    tickets = new TicketAirline()
                    {
                        UserId = reys.Id,
                        PlaceAirlineId = place.Id,
                        From = reys.Flight_From,
                        For = reys.Flight_For,
                        dateTime = reys.Date,
                        PasportSeries = command.PasportSeries
                    };
                }
                else
                {
                    throw new Exception("Invalid pasport or not enough money");
                }
            }
            else if (command.Status == Status.Buiseness)
            {
                if (_economyService.PaymentCheck(command.PasportSeries, (double)reys.Price))
                {
                    tickets = new TicketAirline()
                    {
                        UserId = reys.Id,
                        PlaceAirlineId = place.Id,
                        From = reys.Flight_From,
                        For = reys.Flight_For,
                        dateTime = reys.Date,
                        PasportSeries = command.PasportSeries
                    };
                }
                else
                {
                    throw new Exception("Invalid pasport or not enough money");
                }
            }
            else if (command.Status == Status.VIP)
            {
                if (_economyService.PaymentCheck(command.PasportSeries, (double)reys.Price))
                {
                    tickets = new TicketAirline()
                    {
                        UserId = reys.Id,
                        PlaceAirlineId = place.Id,
                        From = reys.Flight_From,
                        For = reys.Flight_For,
                        dateTime = reys.Date,
                        PasportSeries = command.PasportSeries
                    };
                }
                else
                {
                    throw new Exception("Invalid pasport or not enough money");
                }
            }

            await _context.ticketAirlines.AddAsync(tickets);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }


}
