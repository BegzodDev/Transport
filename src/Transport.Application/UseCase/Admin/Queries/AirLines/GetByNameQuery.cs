using Transport.Application.Abstractions;
using Transport.Application.DTOs;

namespace Transport.Application.UseCase.Admin.Queries.AirLines
{
    public class GetByNameQuery : IQuery<List<AirLineViewModel>>
    {
        public string SearchText { get; set; } = string.Empty;
    }
    public class GetByNameQueryHandler : IQueryHandler<GetByNameQuery, List<AirLineViewModel>>
    {
        private readonly IApplicationDbContext _context;
        public GetByNameQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<AirLineViewModel>> Handle(GetByNameQuery request, CancellationToken cancellationToken)
        {
            //    return await _context.airlines
            //        .Include(x => x.Flight_From);
            throw new NotImplementedException();
        }
    }
}