using MediatR;
using Microsoft.EntityFrameworkCore;
using Transport.Application.Abstractions;
using Transport.Application.Exceptions;
using Transport.Domain.Entities;

namespace Transport.Application.UseCase.User.Commands
{
    public class UpdateTicketAirlineCommand : ICommand<Unit>
    {
        public string? PasportSeries { get; set; }
        public DateOnly Date { get; set; }
    }
    public class UpdateTicketAirlineCommandHandler : ICommandHandler<UpdateTicketAirlineCommand, Unit>
    {
        private readonly IApplicationDbContext _context;

        public UpdateTicketAirlineCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateTicketAirlineCommand command, CancellationToken cancellationToken)
        {
            var ticket = await _context.ticketAirlines.FirstOrDefaultAsync(x => x.PasportSeries == command.PasportSeries, cancellationToken);

            if (ticket == null)
            {
                throw new AirlineNotFoundException();
            }
            

            ticket.dateTime = command.Date.ToDateTime(TimeOnly.MinValue);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
