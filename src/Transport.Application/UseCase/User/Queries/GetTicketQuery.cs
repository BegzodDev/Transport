using MediatR;
using Microsoft.EntityFrameworkCore;
using Transport.Application.Abstractions;
using Transport.Application.DTOs;

namespace Transport.Application.UseCase.User.Queries
{
    public class GetTicketQuery : IQuery<TicketAirlineViewModel>
    {
        public int UserId { get; set; }
    }

    public class GetTicketQueryHandelr : IQueryHandler<GetTicketQuery, TicketAirlineViewModel>
    {
        private readonly IApplicationDbContext _context;

        public GetTicketQueryHandelr(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TicketAirlineViewModel> Handle(GetTicketQuery query,CancellationToken cancellationToken)
        {
            var ticket = await _context.ticketAirlines.FirstOrDefaultAsync(x=>x.UserId == query.UserId);

            if (ticket == null)
            {
                throw new Exception("Ticket Not Found");
            }

            return (TicketAirlineViewModel)ticket;
        }
    }
}
