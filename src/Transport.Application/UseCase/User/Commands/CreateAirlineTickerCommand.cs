﻿using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System.ComponentModel.DataAnnotations;
using Transport.Application.Abstractions;
using Transport.Application.Exceptions;
using Transport.Domain.Entities;
using Transport.Domain.Enums;

namespace Transport.Application.UseCase.User.Commands
{
    public class CreateAirlineTickerCommand : ICommand<Unit>
    {
        [Required]
        public string? PasportSeies { get; set; }

        public DateTime Date { get; set; }
        [Required]
        public string From { get; set; }
        [Required]
        public string For { get; set; }
        [Required]
        public int Place { get; set; }
        [Required]
        public Status Status { get; set; }
    }
    public class CreateAirlineTickerCommandHandler : ICommandHandler<CreateAirlineTickerCommand, Unit>
    {
        //Interfaces
        private readonly IApplicationDbContext _context;
        private readonly IGovermentService _govermentService;
        private readonly ISecurityService _securityService;
        private readonly IEconomyService _economyService;
        private readonly ICurrentUserService _currentUserService;
        private readonly IDistributedCache _distrubuteCache;

        //Constructor
        public CreateAirlineTickerCommandHandler(IApplicationDbContext context,
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

        public async Task<Unit> Handle(CreateAirlineTickerCommand command, CancellationToken cancellationToken)
        {
            //Check Pasport from goverment
            if (!_govermentService.Check(command.PasportSeies!))
            {
                throw new Exception("Pasport series is Don't have in our Base");
            }
            //Check Pasport from Secure
            _securityService.CheckSecure(command.PasportSeies!);
            var reys = _context.airlines.FirstOrDefault(x => x.Flight_From!.ToLower() == command.From!.ToLower() &&
                                                        x.Flight_For!.ToLower() == command.For!.ToLower() &&
                                                        x.Date == command.Date);

            var reys = _context.airlines.FirstOrDefault(x => x.Flight_From.ToLower() == command.From.ToLower() &&
                                                        x.Flight_For.ToLower() == command.For.ToLower() &&
                                                        x.Date.Year == command.Date.Year &&
                                                        x.Date.Month == command.Date.Month &&
                                                        x.Date.Day == command.Date.Day);

            if (reys == null)
            {
                throw new AirlineNotFoundException();
            }
            if (command.Status == Status.Econom)
            {
                foreach (var places in _context.placeAirlines)
                {
                    if (places.Place_in_Ticket == command.Place && places.Status == Status.Econom)
                    {
                        throw new Exception("This place is busy");
                    }
                    continue;
                }
            }
            if (command.Status == Status.Buiseness)
            {
                foreach (var places in _context.placeAirlines)
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
                foreach (var places in _context.placeAirlines)
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

            var user = _context.users.FirstOrDefault(x => x.Id == _currentUserService.UserId);


            var tickets = new TicketAirline();
            await _context.placeAirlines.AddAsync(place);
            await _context.SaveChangesAsync(cancellationToken);



            //Check Pay from economy
            if (!_economyService.PaymentCheck(command.PasportSeies!, (double)reys.Price!))
            {
                throw new Exception("Payment is valid");
            }

            else if (command.Status == Status.Econom)
            {
                if (_economyService.PaymentCheck(command.PasportSeies!, (double)reys.Price))
                {
                    tickets = new TicketAirline()
                    var ticket = new TicketAirline()
                    {
                        
                        UserId = _currentUserService.UserId,
                        PlaceAirlineId = place.Id,

                        From = reys.Flight_From,
                        For = reys.Flight_For,
                        dateTime = reys.Date,
                        PasportSeries = command.PasportSeies,
                    };
                    await _context.ticketAirlines.AddAsync(ticket);

                }
                else { throw new Exception("Invalid pasport or not enoughmoney"); }
            }
            else if (command.Status == Status.Buiseness)
            {
                if (_economyService.PaymentCheck(command.PasportSeies!, ((double)reys.Price) * 1.5))
                {
                   var ticket = new TicketAirline()
                    {
                        UserId = _currentUserService.UserId,
                        PlaceAirlineId = place.Id,
                        From = reys.Flight_From,
                        For = reys.Flight_For,
                        dateTime = reys.Date,
                        PasportSeries = command.PasportSeies

                    };
                    await _context.ticketAirlines.AddAsync(ticket);

                }
                else { throw new Exception("Invalid pasport or not enoughmoney"); }

            }
            else if (command.Status == Status.VIP)
            {
                if (_economyService.PaymentCheck(command.PasportSeies!, ((double)reys.Price) * 2.5))
                {

                    var ticket = new TicketAirline()
                    {
                        UserId = _currentUserService.UserId,
                        PlaceAirlineId = place.Id,
                        From = reys.Flight_From,
                        For = reys.Flight_For,
                        dateTime = reys.Date,
                        PasportSeries = command.PasportSeies

                    };
                    await _context.ticketAirlines.AddAsync(ticket);

                }
                else { throw new Exception("Invalid pasport or not enoughmoney"); }
            }

            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
