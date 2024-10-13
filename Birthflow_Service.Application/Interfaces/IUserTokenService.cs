using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthflowService.Application.Interfaces
{
    public interface IUserTokenService
    {
        /// <summary>
        /// Obtiene el UserName del usuario logueado por medio del token.
        /// </summary>
        /// <returns>UserName: string</returns>
        string GetUserName();

        /// <summary>
        /// Obtiene el nombre completo del usuario logueado por medio del token.
        /// </summary>
        /// <returns>Full name: string</returns>
        string GetUserFullName();

        /// <summary>
        /// Obtiene el Id del usuario logueado por medio del token.
        /// </summary>
        /// <returns>UserId: Guid</returns>
        Guid GetUserId();

        /// <summary>
        /// Obtiene el correo del usuario logueado por medio del token.
        /// </summary>
        /// <returns>Email: string</returns>
        string GetUserEmail();

        /// <summary>
        /// Obtiene la  IP del usuario logueado por medio del token.
        /// </summary>
        /// <returns>IP: string</returns>
        string GetIpAddress();

        /// <summary>
        /// Obtiene la  IP del usuario logueado por medio del token.
        /// </summary>
        /// <returns>IP: string</returns>
        string GetDevice();
    }
}
