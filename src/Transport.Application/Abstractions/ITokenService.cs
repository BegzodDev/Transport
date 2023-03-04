using System.Security.Claims;

namespace Transport.Application.Abstractions
{
    public interface ITokenService
    {
        string GetAccessToken(Claim[] claims);
    }
}
