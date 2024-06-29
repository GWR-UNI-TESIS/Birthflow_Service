using Birthflow_Application.DTOs.Auth;
using Birthflow_Domain.Interface;
using Birthflow_Service.Infraestructure.DbContexts;
using BirthflowMicroServices.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Birthflow_Application.DTOs.Auth.UsuarioEntityDto;

namespace Birthflow_Infraestructure.Repositories
{
    public class AuthRepository : IAuthServices
    {
        private readonly BirthflowDbContext _context;

        public AuthRepository(BirthflowDbContext context)
        {
          _context = context;
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
            var isExistedUser = _context.Users.FirstOrDefault(u => u.UserName == user.NombreUsuario
                                                              || u.Email == user.Email
                                                              || u.UserName == user.NombreUsuario);
            
            if (isExistedUser != null)
            {
                var newUserEntity = new UsuarioEntity() {
                    Nombres = user.Nombres,
                    Apellidos = user.Apellidos,
                    NombreUsuario = user.NombreUsuario,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    RolId = user.RolId,
                    IsDelete = user.IsDelete,
                    CreatedAt = DateTime.Now,
                    //CreatedBy = 1,
                    UpdatedAt = null,


                };
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
