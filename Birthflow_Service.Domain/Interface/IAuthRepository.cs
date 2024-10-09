using BirthflowService.Domain.Entities;

namespace BirthflowService.Domain.Interface
{
    public interface IAuthRepository
    {
        RefreshTokenEntity GetRefreshToken(Guid username, string RefreshToken);

        public void DeleteUserRefreshTokens(Guid username, string refreshToken);

        public RefreshTokenEntity AddUserRefreshTokens(RefreshTokenEntity user);

        public Task AddLoginAttempt(UserLoginAttemptEntity entity);

    }
}
