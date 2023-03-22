using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Transport.Application.Abstractions;
using Transport.Application.DTOs;
using Transport.Application.Exceptions;

namespace Transport.Application.UseCase.User.Queries
{
    public class GetBusTicketQuery : IQuery<TicketBusViewModel>
    {
        public string PassportSeria { get; set; }
    }

    public class GetBusTicketsQueryHandler : IQueryHandler<GetBusTicketQuery, TicketBusViewModel>
    {
        private readonly IApplicationDbContext _context;

        public GetBusTicketsQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TicketBusViewModel> Handle(GetBusTicketQuery request, CancellationToken cancellationToken)
        {
            var ticket = await _context.ticketBuses.FirstOrDefaultAsync(x => x.PassportSeria == request.PassportSeria, cancellationToken);
            
            if (ticket == null)
            {
                throw new Exception("Ticket not found");
            }
            var viewTicket = new TicketBusViewModel()
            {
                For = ticket.For,
                From = ticket.From,
                Date = ticket.Date,
                PasportSeries = ticket.PassportSeria
            };

            return viewTicket;
        }
    }

}