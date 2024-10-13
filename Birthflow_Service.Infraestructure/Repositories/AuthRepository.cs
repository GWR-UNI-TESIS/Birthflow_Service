using Birthflow_Service.Infraestructure.DbContexts;
using BirthflowService.Domain.Entities;
using BirthflowService.Domain.Interface;
using Microsoft.EntityFrameworkCore;

namespace BirthflowService.Infraestructure.Repositories
{
    public class AuthRepository : IAuthRepository
    {

        private readonly BirthflowDbContext _context;

        public AuthRepository(BirthflowDbContext context)
        {
            _context = context;
        }

        public RefreshTokenEntity AddUserRefreshTokens(RefreshTokenEntity user)
        {
            _context.RefreshTokenEntities.Add(user);
            _context.SaveChanges();
            return user;
        }

        public async Task<RefreshTokenEntity> UpdateUserRefreshTokens(RefreshTokenEntity refreshToken)
        {
            _context.RefreshTokenEntities.Update(refreshToken);
            await _context.SaveChangesAsync();
            return refreshToken;
        }
    

        public void DeleteUserRefreshTokens(Guid username, string refreshToken)
        {
            var item = _context.RefreshTokenEntities.FirstOrDefault(x => x.UserId == username && x.RefreshTokenValue == refreshToken);
            if (item != null)
            {
                _context.RefreshTokenEntities.Remove(item);
            }
        }

        public async Task<RefreshTokenEntity?> GetRefreshToken(Guid userId, string RefreshToken)
        {
            return await _context.RefreshTokenEntities.FirstOrDefaultAsync(x => x.UserId == userId && x.RefreshTokenValue == RefreshToken && x.Active)!;
        }

        public async Task AddLoginAttempt(UserLoginAttemptEntity entity)
        {
            try
            {
                await _context.UserLoginAttemptEntities.AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<UserSessionHistoryEntity?> GetActiveSessionByUserId(Guid userId)
        {
            try
            {
                var session = await _context.UserSessionHistoryEntities
                   .Where(s => s.UserId == userId && s.IsActive)
                   .OrderByDescending(s => s.SessionStartTime).FirstOrDefaultAsync();

                // Verificar si la última actividad supera el umbral de tiempo (ejemplo, 1 hora)
                if (session != null && session.LastActivity < DateTime.UtcNow.AddHours(-1))
                {
                    // Si la sesión está inactiva por más de 1 hora, cerrarla
                    session.IsActive = false;
                    session.SessionEndTime = DateTime.UtcNow;
                    await _context.SaveChangesAsync();
                    return null;
                }

                return session;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<UserSessionHistoryEntity?> GetActiveSessionByUserIdAndDeviceId(Guid userId, string deviceId)
        {
            return await _context.UserSessionHistoryEntities
                .FirstOrDefaultAsync(s => s.UserId == userId && s.Device == deviceId && s.IsActive);
        }

        public async Task<UserSessionHistoryEntity?> AddUserSession(UserSessionHistoryEntity entity)
        {
            try
            {
                await _context.UserSessionHistoryEntities.AddAsync(entity);
                await _context.SaveChangesAsync();

                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<UserSessionHistoryEntity?> UpdateUserSession(UserSessionHistoryEntity entity)
        {
            try
            {
                _context.UserSessionHistoryEntities.Update(entity);
                await _context.SaveChangesAsync();

                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<UserSessionHistoryEntity?> GetSessionByRefreshToken(string token)
        {
            try
            {
                var result = await _context.UserSessionHistoryEntities.FirstOrDefaultAsync(ush => ush.SessionToken == token);
                await _context.SaveChangesAsync();

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<RefreshTokenEntity?> GetRefreshTokenByUserIdAndDeviceId(Guid userId, string deviceId)
        {
            return await _context.RefreshTokenEntities
                .FirstOrDefaultAsync(r => r.UserId == userId && r.Device == deviceId && r.Active);
        }
    }
}
