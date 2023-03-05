using MediatR;
using Microsoft.EntityFrameworkCore;
using Transport.Application.Abstractions;
using Transport.Application.Exceptions;

namespace Transport.Application.UseCase.User.Commands
{
    public class DeleteTicketAirlineCommand : ICommand<Unit>
    {
        public int Id { get; set; }
    }
    public class DeleteTicketAirlineCommandHandler : ICommandHandler<DeleteTicketAirlineCommand, Unit>
    {
        private readonly IApplicationDbContext _context;
        public DeleteTicketAirlineCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteTicketAirlineCommand commamd, CancellationToken cancellationToken)
        {
            var ticket = await _context.ticketAirlines.FirstOrDefaultAsync(x => x.Id == commamd.Id);

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
