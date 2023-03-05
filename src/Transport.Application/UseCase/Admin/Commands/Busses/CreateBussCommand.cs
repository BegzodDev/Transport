using Transport.Application.Abstractions;
using Transport.Domain.Entities;

namespace Transport.Application.UseCase.Admin.Commands.Busses
{
    public class CreateBussCommand : ICommand<int>
    {
        public string? From { get; set; }
        public string? For { get; set; }
        public double? Price { get; set; }
        public int? OrderForBusId { get; set; }

    }
    public class CreateBussCommandHandler : ICommandHandler<CreateBussCommand, int>
    {
        private readonly IApplicationDbContext _context;
        public CreateBussCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateBussCommand request, CancellationToken cancellationToken)
        {
            var entity = new Bus()
            {
                From = request.From,
                For = request.For,
                Price = request.Price,
                OrderForBusId = request.OrderForBusId,
            };
            await _context.bus.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}
