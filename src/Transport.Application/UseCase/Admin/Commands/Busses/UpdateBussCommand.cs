using MediatR;
using Microsoft.EntityFrameworkCore;
using Transport.Application.Abstractions;
using Transport.Application.Exceptions;
using Transport.Domain.Entities;

namespace Transport.Application.UseCase.Admin.Commands.Busses
{
    public class UpdateBussCommand : ICommand<Unit>
    {
        public int Id { get; set; }
        public string? From { get; set; }
        public string? For { get; set; }
        public double? Price { get; set; }
        public int? OrderForBusId { get; set; }
        public OrderForBus? OrderForBus { get; set; }
    }
    public class UpdateBussCommandHandler : ICommandHandler<UpdateBussCommand, Unit>
    {
        private readonly IApplicationDbContext _context;
        public UpdateBussCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(UpdateBussCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.bus.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (entity == null)
            {
                throw new BusNotFoundException();
            }

            entity.From = request.From ?? entity.From;
            entity.For = request.For ?? entity.For;
            entity.Price = request.Price == 0 ? entity.Price : request.Price;
            entity.OrderForBusId = request.OrderForBusId ?? entity.OrderForBusId;
            entity.OrderForBus = request.OrderForBus ?? entity.OrderForBus;

            _context.bus.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}