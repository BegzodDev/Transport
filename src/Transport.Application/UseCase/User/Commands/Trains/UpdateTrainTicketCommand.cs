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

namespace Transport.Application.UseCase.User.Commands.Trains
{
    public class UpdateTrainTicketCommand : ICommand<Unit>
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
    }

    public class UapdateTrainTicketCommandHandler : ICommandHandler<UpdateTrainTicketCommand, Unit>
    {
        private readonly IApplicationDbContext _context;

        public UapdateTrainTicketCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateTrainTicketCommand command, CancellationToken cancellationToken)
        {
            var ticket = await _context.ticketTrains.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken);

            if (ticket == null)
            {
                throw new TrainNotFoundException();
            }

            ticket.dateTime = command.Date;
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
