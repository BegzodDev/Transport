﻿using Microsoft.EntityFrameworkCore;
using Transport.Application.Abstractions;
using Transport.Application.DTOs;
using Transport.Application.Exceptions;

namespace Transport.Application.UseCase.User.Queries
{
    public class GetAirlineTicketQuery : IQuery<TicketAirlineViewModel>
    {
        public string? PasportSeries { get; set; }
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
            var ticket = await _context.ticketAirlines.FirstOrDefaultAsync(x => x.PasportSeries == query.PasportSeries);

            if (ticket == null)
            {
                throw new AirlineNotFoundException();
            }

            return (TicketAirlineViewModel)ticket;
        }
    }
}