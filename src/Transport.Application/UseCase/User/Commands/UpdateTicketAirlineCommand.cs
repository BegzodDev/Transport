using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Transport.Application.Abstractions;
using Transport.Application.Exceptions;

namespace Transport.Application.UseCase.User.Commands
{
    public class UpdateTicketAirlineCommand : ICommand<Unit>
    {
        public int Id { get; set; }
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
            var ticket = await _context.ticketAirlines.FirstOrDefaultAsync(x => x.Id == command.Id,cancellationToken);

            if (ticket == null)
            {
                throw new AirlineNotFoundException();
            }

            ticket.dateTime = command.Date;
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
