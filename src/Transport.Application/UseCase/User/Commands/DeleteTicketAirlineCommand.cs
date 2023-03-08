using MediatR;
using Microsoft.EntityFrameworkCore;
using Transport.Application.Abstractions;
using Transport.Application.Exceptions;

namespace Transport.Application.UseCase.User.Commands
{
    public class DeleteTicketAirlineCommand : ICommand<Unit>
    {
        public string? PasportSeries { get; set; }
    }
    public class DeleteTicketAirlineCommandHandler : ICommandHandler<DeleteTicketAirlineCommand, Unit>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;
        public DeleteTicketAirlineCommandHandler(IApplicationDbContext context,ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService= currentUserService;
        }

        public async Task<Unit> Handle(DeleteTicketAirlineCommand commamd, CancellationToken cancellationToken)
        {
            var ticket = await _context.ticketAirlines.FirstOrDefaultAsync(x => x.PasportSeries == commamd.PasportSeries 
                                                                            && x.UserId == _currentUserService.UserId);

            if (ticket == null)
            {
                throw new AirlineNotFoundException();
            }

            _context.ticketAirlines.Remove(ticket);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }

}
