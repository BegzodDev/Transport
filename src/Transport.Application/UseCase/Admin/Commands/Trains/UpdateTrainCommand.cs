using MediatR;
using Microsoft.EntityFrameworkCore;
using Transport.Application.Abstractions;
using Transport.Application.Exceptions;

namespace Transport.Application.UseCase.Admin.Commands.Trains
{
    public class UpdateTrainCommand : ICommand<Unit>
    {
        public int Id { get; set; }
        public string? From { get; set; }
        public string? For { get; set; }
        public double? Price { get; set; }

        public DateTime? Date { get; set; }
        public int? Count_Business_Class_Place { get; set; }
        public int? Count_Econom_Class_Place { get; set; }
        public int? Count_VIP_Class_Place { get; set; }
    }
    public class UpdateTrainCommandHandler : ICommandHandler<UpdateTrainCommand, Unit>
    {
        private readonly IApplicationDbContext _context;
        public UpdateTrainCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(UpdateTrainCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.trains.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (entity == null)
            {
                throw new TrainNotFoundException();
            }
            entity.From = request.From ?? entity.From;
            entity.For = request.For ?? entity.For;
            entity.Price = request.Price == 0 ? entity.Price : request.Price;
            entity.Date = request.Date ?? entity.Date;
            entity.Count_Business_Class_Place = request.Count_Business_Class_Place ?? entity.Count_Business_Class_Place;
            entity.Count_VIP_Class_Place = request.Count_VIP_Class_Place ?? entity.Count_VIP_Class_Place;
            entity.Count_Econom_Class_Place = request.Count_Econom_Class_Place ?? entity.Count_Econom_Class_Place;

            _context.trains.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}