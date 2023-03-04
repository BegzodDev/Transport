using MediatR;
using Microsoft.EntityFrameworkCore;
using Transport.Application.Abstractions;
using Transport.Application.Exceptions;

namespace Transport.Application.UseCase.Admin.Commands.Busses
{
    public class DeleteBussCommand : ICommand<Unit>
    {
        public int Id { get; set; }
    }
    public class DeleteBussCommandHandler : ICommandHandler<DeleteBussCommand, Unit>
    {
        private readonly IApplicationDbContext _context;
        public DeleteBussCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(DeleteBussCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.bus.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (entity == null)
            {
                throw new BusNotFoundException();
            }
            _context.bus.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
