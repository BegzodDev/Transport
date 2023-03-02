using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Transport.Application.Abstractions;
using Transport.Application.Exceptions;
using Transport.Domain.Exceptions;

namespace Transport.Application.UseCase.Auth.Commands
{
    public class LoginCommand : IRequest<string>
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    /*public class LoginComandHandler : IRequestHandler<LoginCommand, string>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IHashService _hashService;
        private readonly ITokenService _tokenService;

        public LoginComandHandler(IApplicationDbContext applicationDbContext, IHashService hashService, ITokenService tokenService)
        {
            _applicationDbContext = applicationDbContext;
            _hashService = hashService;
            _tokenService = tokenService;
        }*/

       /* public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _applicationDbContext.users.FirstOrDefaultAsync(x => x.UserName == request.UserName, cancellationToken);

            if (user == null)
            {
                throw new LoginException(new EntityNotFoundException(nameof(User)));
            }
            if (user.PasswordHash != _hashService.GetHash(request.Password))
            {
                throw new LoginException();
            }

            var claims = new List<Claim>
            {
                new (ClaimTypes.NameIdentifier, user.Id.ToString()!),
                new (ClaimTypes.Name, user.UserName!),
            };

            if (await _applicationDbContext.admins.AnyAsync(x => x.Id == user.Id, cancellationToken))
            {
                claims.Add(new Claim(ClaimTypes.Role, nameof(Domain.Entities.Admin)));
                claims.Add(new Claim(ClaimTypes.Role, nameof(Domain.Entities.User)));
            }

            if (await _applicationDbContext.users.AnyAsync(x => x.Id == user.Id, cancellationToken))
            {
                claims.Add(new Claim(ClaimTypes.Role, nameof(Domain.Entities.User)));
            }

            return _tokenService.GetAccessToken(claims.ToArray());

        }
    }*/

}
