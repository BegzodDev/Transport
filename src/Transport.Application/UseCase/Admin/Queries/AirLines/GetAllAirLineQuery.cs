using Microsoft.EntityFrameworkCore;
using Transport.Application.Abstractions;
using Transport.Application.DTOs;

namespace Transport.Application.UseCase.Admin.Queries.AirLines
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
                Flight_From = x.Flight_From,
                Flight_For = x.Flight_For,
                Price = x.Price,
                Date = x.Date,
                Count_Business_Class_Place = x.Count_Business_Class_Place,
                Count_Econom_Class_Place = x.Count_Econom_Class_Place,
                Count_VIP_Class_Place = x.Count_VIP_Class_Place
            }).ToListAsync(cancellationToken);
        }
    }
}