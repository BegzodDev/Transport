using MediatR;
using Microsoft.EntityFrameworkCore;
using Transport.Application.Abstractions;
using Transport.Application.DTOs;
using Transport.Domain.Entities;
using Transport.Domain.Enums;

namespace Transport.Application.UseCase.User.Commands
{
    public class CreateBussTicketCommand : ICommand<Unit>
    {
        public string? PasportSeies { get; set; }
        public string For { get; set; }
        public string From { get; set; }
        public Station Station { get; set; }
        public double? Price { get; set; }
    }

    public class CreateBussCommandHandler : ICommandHandler<CreateBussTicketCommand, Unit>
    {
        private readonly IApplicationDbContext _context;
        private readonly IGovermentService _governmentService;
        private readonly ISecurityService _securityService;
        private readonly IEconomyService _economyService;
        private readonly ICurrentUserService _currentUserService;

        public CreateBussCommandHandler(IApplicationDbContext context,IGovermentService governmentService, 
                                        ISecurityService securityService, IEconomyService economyService,
                                        ICurrentUserService currentUserService)
        {
            _governmentService = governmentService;
            _securityService = securityService;
            _currentUserService = currentUserService;
            _economyService = economyService;
            _context = context;
        }

        public async Task<Unit> Handle(CreateBussTicketCommand request, CancellationToken cancellationToken)
        {

            var bus = await _context.bus.FirstOrDefaultAsync(x => x.From == request.From &&
                                                                  x.For == request.For);
            if (bus == null)
            {
                throw new Exception("Bus not found ");
            }

            if (_governmentService.Check(request.PasportSeies))
            {
                throw new Exception("User Not Found");
            }

            if (_economyService.PaymentCheck(request.PasportSeies, (double)request.Price))
            {
                throw new Exception("payment is unavailable");
            }

            if (_securityService.CheckSecure(request.PasportSeies))
            {
                throw new Exception("User is not secure");
            }

            var currentUser = _context.users.FirstOrDefaultAsync(x => x.Id == _currentUserService.UserId);
            var result = new TicketBusViewModel()
            {
                
                From = request.From,
                For = request.For,
                PasportSeries = request.PasportSeies,
            };

            var busTicket = new TicketBus()
            {
                BusId = bus.Id,
                Date = DateTime.UtcNow,
                Sum = (double)bus.Price,
                UserId = _currentUserService.UserId,
            };

            await _context.ticketBuses.AddAsync(busTicket, cancellationToken);

            return Unit.Value;
        }
    }
}
