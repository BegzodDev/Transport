using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Transport.Application.Abstractions;

namespace Transport.Application.UseCase.User.Commands
{
    public class TakeTicketFromCacheCommand : ICommand<Unit>
    {
        private readonly IMediator? _mediator;
        private readonly IApplicationDbContext? _context;
        private readonly ICurrentUserService? _currentUserService;
        private readonly IDistributedCache? _distributedCache;

        public TakeTicketFromCacheCommand(IMediator? mediator, IApplicationDbContext? context, ICurrentUserService? currentUserService, IDistributedCache? distributedCache)
        {
            _mediator = mediator;
            _context = context;
            _currentUserService = currentUserService;
            _distributedCache = distributedCache;
        }
        
    }
}
