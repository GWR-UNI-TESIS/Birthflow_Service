using BirthflowService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthflowService.Domain.Interface
{
    public interface IAuthRepository
    {
        RefreshTokenEntity GetRefreshToken(Guid username, string RefreshToken);

        public void DeleteUserRefreshTokens(Guid username, string refreshToken);

        public RefreshTokenEntity AddUserRefreshTokens(RefreshTokenEntity user);

    }
}
