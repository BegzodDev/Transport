using MediatR;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Transport.Application.Abstractions;
using Transport.Application.Exceptions;

namespace Transport.Application.UseCase.User.Commands
{
    public class RegisterUserCommand : ICommand<Unit>
    {
        [Required]
        public string? UserName { get; set; }
        public string? Password { get; set; }
        //public string Email { get; set; } = string.Empty;
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
            if (await _dbContext.users.AnyAsync(x => x.UserName == command.UserName, cancellationToken))
            {
                throw new RegisterException(new UserException(nameof(User)));
            }

            var user = new Domain.Entities.User()
            {
                UserName = command.UserName!,
                PasswordHash = _hashService.GetHash(command.Password!),
            };

            await _dbContext.users.AddAsync(user,cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
