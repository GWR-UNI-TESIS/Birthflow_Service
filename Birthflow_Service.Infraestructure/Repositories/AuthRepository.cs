using Birthflow_Service.Infraestructure.DbContexts;
using BirthflowService.Domain.Entities;
using BirthflowService.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void DeleteUserRefreshTokens(Guid username, string refreshToken)
        {
            var item = _context.RefreshTokenEntities.FirstOrDefault(x => x.UserId == username && x.RefreshTokenValue == refreshToken);
            if (item != null)
            {
                _context.RefreshTokenEntities.Remove(item);
            }
        }

        public RefreshTokenEntity GetRefreshToken(Guid username, string RefreshToken)
        {
            return _context.RefreshTokenEntities.FirstOrDefault(x => x.UserId == username && x.RefreshTokenValue == RefreshToken && x.Active)!;
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

    }
}
