using Birthflow_Service.Infraestructure.DbContexts;
using BirthflowService.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthflowService.Application.Services
{
    public class UserTokenService : IUserTokenService
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public UserTokenService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        /// <summary>
        /// Obtiene el UserName del usuario logueado por medio del token
        /// </summary>
        /// <returns>UserName: string</returns>
        public string GetUserName()
        {
            var userName = _contextAccessor.HttpContext?.Items["UserName"] as string;

            return userName ?? "UserName not found";
        }

        public string GetUserFullName()
        {
            var userName = _contextAccessor.HttpContext?.Items["Name"] as string;

            return userName ?? "Full name not found";
        }

        /// <summary>
        /// Obtiene el Id del usuario logueado por medio del token
        /// </summary>
        /// <returns>UserId: Integer</returns>
        public Guid GetUserId()
        {
            var userId = _contextAccessor.HttpContext?.Items["UserId"] as string;

            if (Guid.TryParse(userId, out var parsedUserId))
            {
                return parsedUserId;
            }

            throw new InvalidOperationException("UserId is not a valid GUID");
        }
        /// <summary>
        /// Obtiene el correo del usuario logueado por medio del token
        /// </summary>
        /// <returns>Email: string</returns>
        public string GetUserEmail()
        {
            var email = _contextAccessor.HttpContext?.Items["Email"] as string;

            return email ?? "Email not found";
        }
    }
}
