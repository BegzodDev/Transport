using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Transport.Application.Abstractions;
using Transport.Infrastructure.Configurations;

namespace Transport.Infrastructure.Services
{
    public class JWTService : ITokenService
    {
        private readonly JWTConfiguration _jwtConfiguration;
        public JWTService(IOptions<JWTConfiguration> jwtConfiguration)
        {
            _jwtConfiguration = jwtConfiguration.Value;
        }

        public string GetAccessToken(Claim[] userClaims)
        {
            var jwtClaims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString())
            };

            var claims = userClaims.Concat(jwtClaims);

            var credentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfiguration.Secret)),
                SecurityAlgorithms.HmacSha256
            );

            var token = new JwtSecurityToken(
                _jwtConfiguration.ValidIssuer,
                _jwtConfiguration.ValidAudience,
                claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: credentials);

            var tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(token);
        }
    }
}
