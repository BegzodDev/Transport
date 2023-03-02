using MediatR;
using Microsoft.EntityFrameworkCore;
using Transport.Application.Abstractions;
using Transport.Application.Exceptions;

namespace Transport.Application.UseCase.Admin.Commands.Trains
{
    public class DeleteTrainCommand : ICommand<Unit>
    {
        public int Id { get; set; }
    }
    public class DeleteTrainCommandHandler : ICommandHandler<DeleteTrainCommand, Unit>
    {
        private readonly IApplicationDbContext _context;
        public DeleteTrainCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(DeleteTrainCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.trains.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (entity == null)
            {
                throw new TrainNotFoundException();
            }
            _context.trains.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}