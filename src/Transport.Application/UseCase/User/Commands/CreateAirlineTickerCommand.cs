using MediatR;
using Microsoft.EntityFrameworkCore;
using Transport.Application.Abstractions;
using Transport.Domain.Entities;
using Transport.Domain.Enums;

namespace Transport.Application.UseCase.User.Commands
{
    public class CreateAirlineTickerCommand : ICommand<Unit>
    {
        public string? PasportSeies { get; set; }
        public DateTime? Date { get; set; }
        public string From { get; set; }
        public string For { get; set; }
        public int Place { get; set; }
        public Status Status { get; set; }
    }
    public class CreateAirlineTickerCommandHandler : ICommandHandler<CreateAirlineTickerCommand, Unit>
    {
        private readonly IApplicationDbContext _context;
        private readonly IGovermentService _govermentService;
        private readonly ISecurityService _securityService;

        public CreateAirlineTickerCommandHandler(IApplicationDbContext context, IGovermentService govermentService,ISecurityService securityService)
        {
            _securityService = securityService;
            _context = context;
            _govermentService = govermentService;
        }

        public async Task<Unit> Handle(CreateAirlineTickerCommand command,CancellationToken cancellationToken)
        {
            if (!_govermentService.Check(command.PasportSeies))
            {
                throw new Exception("Pasport series is Don't have in our Base");
            }
            _securityService.CheckSecure(command.PasportSeies);
            var reys = _context.airlines.FirstOrDefault(x => x.Flight_From.ToLower() == command.From.ToLower() && 
                                                  x.Flight_For.ToLower() == command.For.ToLower() &&
                                                  x.Date == command.Date);
            
            if (reys == null)
            {
                throw new Exception("Can not foun this Reys");
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

            var user = _context.users.FirstOrDefault(x => x.Pasport_Series == command.PasportSeies);
            var ticket = new TicketAirline
            {
                UserId = user.Id,
                dateTime = reys.Date,
                PlaceAirlineId = place.Id
            };

            await _context.ticketAirlines.AddAsync(ticket,cancellationToken);
            await _context.placeAirlines.AddAsync(place,cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
