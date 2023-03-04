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
        public string? Pasport_Series { get; set; }
        public string? SHJR { get; set; }
    }

    public class LoginComandHandler : IRequestHandler<LoginCommand, string>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IHashService _hashService;
        private readonly ITokenService _tokenService;

        public LoginComandHandler(IApplicationDbContext applicationDbContext, IHashService hashService, ITokenService tokenService)
        {
            _applicationDbContext = applicationDbContext;
            _hashService = hashService;
            _tokenService = tokenService;
        }

        public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _applicationDbContext.users.FirstOrDefaultAsync(x => x.Pasport_Series == request.Pasport_Series, cancellationToken);

            if (user == null)
            {
                throw new LoginException(new EntityNotFoundException(nameof(User)));
            }
            if (user.Pasport_Series != _hashService.GetHash(request.SHJR!))
            {
                throw new LoginException();
            }

            var claims = new List<Claim>
            {
                new (ClaimTypes.NameIdentifier, user.Id.ToString()!),
                new (ClaimTypes.Name, user.Pasport_Series!),
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
    }
}