using MediatR;
using Microsoft.EntityFrameworkCore;
using Transport.Application.Abstractions;
using Transport.Application.Exceptions;

namespace Transport.Application.UseCase.Admin.Commands.Airlines
{
    public class DeleteAirlineCommand : ICommand<Unit>
    {
        public int Id { get; set; }
    }
    public class DeleteAirlineCommandHandler : ICommandHandler<DeleteAirlineCommand, Unit>
    {
        private readonly IApplicationDbContext _context;
        public DeleteAirlineCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(DeleteAirlineCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.airlines.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (entity == null)
            {
                throw new AirlineNotFoundException();
            }
            _context.airlines.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
