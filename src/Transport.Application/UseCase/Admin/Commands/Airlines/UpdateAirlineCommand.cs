using MediatR;
using Microsoft.EntityFrameworkCore;
using Transport.Application.Abstractions;
using Transport.Application.Exceptions;

namespace Transport.Application.UseCase.Admin.Commands.Airlines
{
    public class UpdateAirlineCommand : ICommand<Unit>
    {
        public int Id { get; set; }
        public string Flight_From { get; set; } = string.Empty;
        public string Flight_To { get; set; } = string.Empty;  // Flight_For
        public double Price { get; set; }
        public DateTime Date { get; set; }
        public int? Count_Business_Class_Place { get; set; }
        public int? Count_Econom_Class_Place { get; set; }
        public int? Count_VIP_Class_Place { get; set; }
    }
    public class UpdateAirlineCommandHandler : ICommandHandler<UpdateAirlineCommand, Unit>
    {
        private readonly IApplicationDbContext _context;
        public UpdateAirlineCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(UpdateAirlineCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.airlines.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new AirlineNotFoundException();
            }

            entity.Flight_From = request.Flight_From ?? entity.Flight_From;
            entity.Flight_For = request.Flight_To ?? entity.Flight_For;
            entity.Price = request.Price == 0 ? entity.Price : request.Price;
            entity.Date = request.Date;
            entity.Count_Business_Class_Place = request.Count_Business_Class_Place ?? entity.Count_Business_Class_Place;
            entity.Count_VIP_Class_Place = request.Count_VIP_Class_Place ?? entity.Count_VIP_Class_Place;
            entity.Count_Econom_Class_Place = request.Count_Econom_Class_Place ?? entity.Count_Econom_Class_Place;

            _context.airlines.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}