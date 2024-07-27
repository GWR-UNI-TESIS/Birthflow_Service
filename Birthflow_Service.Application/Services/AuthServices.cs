using Birthflow_Application.DTOs;
using Birthflow_Application.DTOs.Auth;
using Birthflow_Application.Utils;
using Birthflow_Domain.Interface;
using Birthflow_Infraestructure.Repositories;
using Birthflow_Service.Infraestructure.DbContexts;
using BirthflowMicroServices.Domain.Models;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
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
            List<Claim> claims = new List<Claim>()
            {
                new Claim("Nombres", user.Nombres!),
                new Claim("Apellidos", user.Apellidos!),
                new Claim("NombreUsuario", user.NombreUsuario!),
                new Claim("Email", user.Email!),
                new Claim("Id", user.Id.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        public string EncryptedPassword(UsuarioEntityDto.UserDto request)
        {
            throw new NotImplementedException();
        }

        public UsuarioEntity? GetByEmail(string email)
        {
            var result = _authRepo.GetByEmail(email);

            return result;
        }

        public UsuarioEntity? GetById(Guid userId)
        {
            var result = _authRepo.GetById(userId);

            return result;
        }

        public UsuarioEntity? GetByUserName(string userName)
        {
            var result = _authRepo.GetByUserName(userName);

            return result;
        }

        //public List<UsuarioEntity> GetUsers(FindExpression findExpression)
        //{
        //    throw new NotImplementedException();
        //}

        public BaseResponse<string> RestartPassword(UsuarioEntity user, string newPassword)
        {
            throw new NotImplementedException();
        }

        public BaseResponse<UsuarioEntity> SaveUser(UsuarioEntityDto user)
        {
            var result =  _authRepo.SaveUser(user);

            return result;
        }

        public BaseResponse<string> UpdateUser(UsuarioEntityDto user, UsuarioEntity currentUser)
        {
            var result = _authRepo.UpdateUser(user, currentUser);

            return result;
        }

        public bool VefiryPassword(string password, string passwordHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, passwordHash);
        }
    }
}
