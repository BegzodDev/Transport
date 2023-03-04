using Transport.Application.Abstractions;
using Transport.Domain.Entities;

namespace Transport.Application.UseCase.Admin.Commands.Trains
{
    public class CreateTrainCommand : ICommand<int>
    {
        public string? From { get; set; }
        public string? For { get; set; }
        public double? Price { get; set; }
        public DateTime? Date { get; set; }
        public int? Count_Business_Class_Place { get; set; }
        public int? Count_Econom_Class_Place { get; set; }
        public int? Count_VIP_Class_Place { get; set; }
    }
    public class CreateTrainCommandHandler : ICommandHandler<CreateTrainCommand, int>
    {
        private readonly IApplicationDbContext _context;
        public CreateTrainCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateTrainCommand request, CancellationToken cancellationToken)
        {
            var entity = new Train()
            {
                From = request.From,
                For = request.For,
                Price = request.Price,
                Date = request.Date,
                Count_Business_Class_Place = request.Count_Business_Class_Place,
                Count_VIP_Class_Place = request.Count_VIP_Class_Place,
                Count_Econom_Class_Place = request.Count_Econom_Class_Place
            };
            await _context.trains.AddAsync(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}
