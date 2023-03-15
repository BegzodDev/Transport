using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.Application.Abstractions;
using Transport.Application.DTOs;
using Transport.Application.Exceptions;


namespace Transport.Application.UseCase.User.Queries
{
    public class GetTrainTicketQuery : IQuery<TrainTicketViewModel>
    {
        public int UserId { get; set; }
    }

    public class GetTicketQueryHanler : IQueryHandler<GetTrainTicketQuery, TrainTicketViewModel>
    {
        private readonly IApplicationDbContext _context;

        public GetTicketQueryHanler(IApplicationDbContext context)
        {
            _context = context
        }

        public async Task<TrainTicketViewModel> Handle(GetTrainTicketQuery query, CancellationToken cancellationToken)
        {
            var ticket = _context.ticketTrains.FirstOrDefaultAsync(x => x.UserId == query.UserId);

            if(ticket == null)
            {
                throw new TrainNotFoundException();
            }

            return (TrainTicketViewModel)ticket;
        }
    }
}
