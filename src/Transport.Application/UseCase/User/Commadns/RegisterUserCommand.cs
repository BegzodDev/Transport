using MediatR;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Transport.Application.Abstractions;
using Transport.Application.Exceptions;

namespace Transport.Application.UseCase.User.Commadns
{
    public class RegisterUserCommand : ICommand<Unit>
    {
        [Required]
        public string? Pasport_Series { get; set; }
        public string? SHJR { get; set; }
        public string Email { get; set; } = string.Empty;
    }

    public class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand, Unit>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IHashService _hashService;

        public RegisterUserCommandHandler(IApplicationDbContext dbContext, IHashService hashService)
        {
            _dbContext = dbContext;
            _hashService = hashService;
        }

        public async Task<Unit> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
        {
            if (await _dbContext.users.AnyAsync(x => x.Pasport_Series == command.Pasport_Series, cancellationToken))
            {
                throw new RegisterException(new UserException(nameof(User)));
            }

            var user = new Domain.Entities.User()
            {
                Pasport_Series = command.Pasport_Series,
                SHJR = _hashService.GetHash(command.SHJR!),
            };

            _dbContext.users.Add(user);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }


    }
}
