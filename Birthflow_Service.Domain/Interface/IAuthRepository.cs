using BirthflowService.Domain.Entities;

namespace BirthflowService.Domain.Interface
{
    public interface IAuthRepository
    {
        Task<RefreshTokenEntity?> GetRefreshToken(Guid username, string RefreshToken);

        public void DeleteUserRefreshTokens(Guid username, string refreshToken);

        public Task<RefreshTokenEntity> UpdateUserRefreshTokens(RefreshTokenEntity refreshToken);

        public RefreshTokenEntity AddUserRefreshTokens(RefreshTokenEntity user);

        public Task<RefreshTokenEntity?> GetRefreshTokenByUserIdAndDeviceId(Guid userId, string deviceId);

        public Task AddLoginAttempt(UserLoginAttemptEntity entity);

        public Task<UserSessionHistoryEntity?> GetActiveSessionByUserId(Guid userId);

        public Task<UserSessionHistoryEntity?> GetActiveSessionByUserIdAndDeviceId(Guid userId, string deviceId);

        public Task<UserSessionHistoryEntity?> AddUserSession(UserSessionHistoryEntity entity);

        public Task<UserSessionHistoryEntity?> UpdateUserSession(UserSessionHistoryEntity entity);

        public Task<UserSessionHistoryEntity?> GetSessionByRefreshToken(string token);
    }
}
