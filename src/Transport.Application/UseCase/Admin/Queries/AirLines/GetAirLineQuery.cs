using Microsoft.EntityFrameworkCore;
using Transport.Application.Abstractions;
using Transport.Domain.Entities;

namespace Transport.Application.UseCase.Admin.Queries.AirLines
{
    public class GetAirLineQuery : IQuery<List<Airline>>
    {
        public int Page { get; set; }
        public int Limit { get; set; } = 10;
        public GetAirLineQuery(int page)
        {
            Page = page;
        }
        public class GetAirLineQueryHandler : IQueryHandler<GetAirLineQuery, List<Airline>>
        {
            private readonly IApplicationDbContext _context;
            public GetAirLineQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<List<Airline>> Handle(GetAirLineQuery request, CancellationToken cancellationToken)
            {
                var skip = request.Page > 0 ? (request.Page - 1) * request.Limit : 0;

                var airlines = await _context.airlines
                    .OrderBy(x => x.Id)
                    .Skip(skip)
                    .Take(request.Limit)
                    .ToListAsync();
                return airlines;
            }
        }
    }
}