using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.Application.Abstractions;
using Transport.Application.Exceptions;

namespace Transport.Application.UseCase.User.Commands.Trains
{
    public class DeleteTrainTicketCommand : ICommand<Unit>
    {
        public int Id { get; set; }
    }
    
    public class DeleteTrainTicketCommandHandler : ICommandHandler<DeleteTrainTicketCommand, Unit>
    {
        private readonly IApplicationDbContext _context;

        public DeleteTicketTrainCommandHandler(IApplicationDbContext context)
        {

            _context = context;
        }

        public async Task<Unit> Handle(DeleteTrainTicketCommand command, CancellationToken cancellationToken)
        {
            var ticket = await _context.ticketTrains.FirstOrDefaultAsync(x => x.Id == command.Id);

            if (ticket == null)
            {
                throw new TrainNotFoundException();
            }

            _context.ticketTrains.Remove(ticket);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
