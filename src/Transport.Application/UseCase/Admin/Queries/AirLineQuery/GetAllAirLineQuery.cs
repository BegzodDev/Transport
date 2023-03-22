using Microsoft.EntityFrameworkCore;
using Transport.Application.Abstractions;
using Transport.Application.DTOs;

namespace Transport.Application.UseCase.Admin.Queries.AirLineQuery
{
    public class GetAllAirLineQuery : IQuery<List<AirLineViewModel>>
    {
    }
    public class GetAllAirQueryHandler : IQueryHandler<GetAllAirLineQuery, List<AirLineViewModel>>
    {
        private readonly IApplicationDbContext _context;
        public GetAllAirQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<AirLineViewModel>> Handle(GetAllAirLineQuery request, CancellationToken cancellationToken)
        {
            return await _context.airlines.Select(x => new AirLineViewModel()
            {
                FlightFrom = x.Flight_From,
                FlightTo = x.Flight_For,
                Price = x.Price,
                Date = x.Date,
                CountBusinessClassPlace = x.Count_Business_Class_Place,
                CountEconomyClassPlace = x.Count_Econom_Class_Place,
                CountVIPClassPlace = x.Count_VIP_Class_Place
            }).ToListAsync(cancellationToken);
        }
    }
}