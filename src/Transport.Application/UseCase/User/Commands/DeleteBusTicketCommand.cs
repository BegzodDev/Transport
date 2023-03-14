using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MediatR;
using Transport.Application.Abstractions;

namespace Transport.Application.UseCase.User.Commands
{
    public class DeleteBusTicketCommand : ICommand<Unit>
    {
        public string PassportSeria { get; set; }
    }

    public class DeleteBusTicketCommandHandler : ICommandHandler<DeleteBusTicketCommand, Unit>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;

        public DeleteBusTicketCommandHandler(IApplicationDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;   
        }

        public async Task<Unit> Handle(DeleteBusTicketCommand request, CancellationToken cancellationToken)
        {
            var ticket = _context.ticketBuses.FirstOrDefault(x => x.PassportSeria == request.PassportSeria
                                                                && x.UserId == _currentUserService.UserId);
            if (ticket == null)
            {
                throw new Exception("Ticket not found");
            }

            _context.ticketBuses.Remove(ticket);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }

}
