using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Transport.Application.Abstractions;

namespace Transport.Application.UseCase.User.Commands
{
    public  class UpdateBusTicketCommand : ICommand<Unit>
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
    }

    public class UpdateBusTicketCommandHandler : ICommandHandler<UpdateBusTicketCommand, Unit>
    {
        private readonly IApplicationDbContext _context;

        public UpdateBusTicketCommandHandler(IApplicationDbContext context)
        {
            _context = context; 
        }

        public async Task<Unit> Handle(UpdateBusTicketCommand request, CancellationToken cancellationToken)
        {
            var ticket = await _context.ticketBuses.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (ticket == null)
            {
                throw new Exception("Ticket not found");
            }

            ticket.Date = request.Date.ToDateTime(TimeOnly.MinValue);
            _context.ticketBuses.Update(ticket);

            return Unit.Value;
        }
    }
}
