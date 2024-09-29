using BirthflowService.Domain.Entities;
using System.Security.Claims;


namespace BirthflowService.Application.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(UserEntity user);
        string GenerateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
