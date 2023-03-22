using Microsoft.EntityFrameworkCore;
using Transport.Application.Abstractions;
using Transport.Application.DTOs;
using Transport.Application.Exceptions;

namespace Transport.Application.UseCase.User.Queries
{
    public class GetAirlineTicketQuery : IQuery<TicketAirlineViewModel>
    {
        public int Id { get; set; }
    }

    public class GetTicketQueryHandelr : IQueryHandler<GetAirlineTicketQuery, TicketAirlineViewModel>
    {
        private readonly IApplicationDbContext _context;

        public GetTicketQueryHandelr(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TicketAirlineViewModel> Handle(GetAirlineTicketQuery query, CancellationToken cancellationToken)
        {
            var ticket = await _context.ticketAirlines.FirstOrDefaultAsync(x => x.UserId == query.Id);

            if (ticket == null)
            {
                throw new AirlineNotFoundException();
            }
            var tick = new TicketAirlineViewModel()
            {
                dateTime = ticket.dateTime,
                PassergerForTrainId = ticket.pas,
                UserId = ticket.UserId,
                PlaceTrainId = ticket.PlaceTrainId
            }w
            return (TicketAirlineViewModel)ticket;
        }
    }
}
