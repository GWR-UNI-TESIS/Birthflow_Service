using Birthflow_Application.DTOs.Auth;
using Birthflow_Application.Utils;
using Birthflow_Domain.Interface;
using Birthflow_Infraestructure.Repositories;
using Birthflow_Service.Infraestructure.DbContexts;
using BirthflowMicroServices.Domain.Models;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birthflow_Application.Services
{
    public class AuthServices : IAuthServices
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<AuthServices> _logger;
        private readonly AuthRepository _authRepo;

        public AuthServices(IConfiguration configuration, AuthRepository authRepo)
        {
            _configuration = configuration;
            _authRepo = authRepo;
        }

        public string ChangePassword(UsuarioEntity user, string newPassword)
        {
            throw new NotImplementedException();
        }

        public string CreateToken(UsuarioEntity user)
        {
            throw new NotImplementedException();
        }

        public UsuarioEntity EncryptedPassword(UserDto request)
        {
            throw new NotImplementedException();
        }

        public UsuarioEntity? GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public UsuarioEntity? GetById(int userId)
        {
            throw new NotImplementedException();
        }

        public UsuarioEntity? GetByUserName(string userName)
        {
            throw new NotImplementedException();
        }

        //public List<UsuarioEntity> GetUsers(FindExpression findExpression)
        //{
        //    throw new NotImplementedException();
        //}

        public UsersSummary GetUsersSummary()
        {
            throw new NotImplementedException();
        }

        public string RestartPassword(UsuarioEntity user, string newPassword)
        {
            throw new NotImplementedException();
        }

        public UsuarioEntity SaveUser(UsuarioEntityDto user)
        {
            try
            {
                var existEmail = GetByEmail(user.Email);
            }
            catch (Exception ex)
            {

                throw;
            }
            throw new NotImplementedException();
        }

        public string UpdateUser(UsuarioEntityDto user, UsuarioEntity currentUser)
        {
            throw new NotImplementedException();
        }

        public bool VefiryPassword(string password, string passwordHash)
        {
            throw new NotImplementedException();
        }
    }
}
