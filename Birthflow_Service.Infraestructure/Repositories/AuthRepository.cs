using Birthflow_Application.DTOs;
using Birthflow_Application.DTOs.Auth;
using Birthflow_Domain.Interface;
using Birthflow_Service.Infraestructure.DbContexts;
using BirthflowMicroServices.Domain.Models;
using Microsoft.AspNetCore.Http;
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

        public string EncryptedPassword(UserDto request)
        {
            UsuarioEntity user = new UsuarioEntity();
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            return passwordHash;
        }

        public UsuarioEntity? GetByEmail(string email)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Email == email);
        }

        public UsuarioEntity? GetById(Guid userId)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Id == userId);
        }

        public UsuarioEntity? GetByUserName(string userName)
        {
            return _context.Usuarios.FirstOrDefault(u => u.NombreUsuario == userName);
        }

        public UsersSummary GetUsersSummary()
        {
            throw new NotImplementedException();
        }

        public BaseResponse<string> RestartPassword(UsuarioEntity user, string newPassword)
        {
            throw new NotImplementedException();
        }

        public BaseResponse<UsuarioEntityDto> SaveUser(UsuarioEntityDto user)
        {
            try
            {
                var isExistedEmail = GetByEmail(user.Email);

                if (isExistedEmail is not null)
                {
                    return new BaseResponse<UsuarioEntityDto>
                    {
                        Message = "Este correo ya existe",
                        Response = null,
                        StatusCode = StatusCodes.Status400BadRequest
                    };
                }

                var isExistedUserName = GetByUserName(user.Email);

                if (isExistedEmail is not null)
                {
                    return new BaseResponse<UsuarioEntityDto>
                    {
                        Message = "Este username ya existe",
                        Response = null,
                        StatusCode = StatusCodes.Status400BadRequest
                    };
                }

                var encrypted = EncryptedPassword(new UserDto { Email = user.NombreUsuario, Password = user.PasswordHash });

                var newUserEntity = new UsuarioEntity()
                {
                    Nombres = user.Nombres,
                    Apellidos = user.Apellidos,
                    NombreUsuario = user.NombreUsuario,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    PasswordHash = encrypted,
                    IsDelete = false,
                    CreatedAt = DateTime.Now,
                    CreatedBy = 1,
                    UpdatedAt = null,
                    UpdatedBy = null,
                    DeletedAt = null,
                    DeletedBy = null
                };

                _context.Entry(newUserEntity).State = Microsoft.EntityFrameworkCore.EntityState.Added;

                _context.Add<UsuarioEntity>(newUserEntity);

                _context.SaveChanges();

                var dto = new UsuarioEntityDto()
                {
                    Id = user.Id,
                    Nombres = newUserEntity.Nombres,
                    Apellidos = newUserEntity.Apellidos,
                    NombreUsuario = newUserEntity.NombreUsuario,
                    Email = newUserEntity.Email,
                    PhoneNumber = newUserEntity.PhoneNumber,
                    PasswordHash = null,
                };

                return new BaseResponse<UsuarioEntityDto>
                {
                    Response = dto,
                    Message = "El usuario a sido creado correctamente",
                    StatusCode = StatusCodes.Status200OK,
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<UsuarioEntityDto>
                {
                    Response = null,
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status400BadRequest,
                };
            }            
        }

        public BaseResponse<string> UpdateUser(UsuarioEntityDto user, UsuarioEntity currentUser)
        {
            try
            {
                var existEmail = GetByEmail(user.Email);
                if (existEmail is not null && user.Email != currentUser.Email)
                    return new BaseResponse<string>
                    {
                        Response = user.Email,
                        Message = "mail already exist",
                        StatusCode = StatusCodes.Status400BadRequest,
                    };

                var existUsername = GetByUserName(user.NombreUsuario);
                if (existUsername is not null && user.NombreUsuario != currentUser.NombreUsuario)
                    return new BaseResponse<string>
                    {
                        Response = user.NombreUsuario,
                        Message = "user already exist",
                        StatusCode = StatusCodes.Status400BadRequest,
                    };

                //var encrypted = EncryptedPassword(new UserDto { UserName = user.UserName, Password = user.PasswordHash });

                //user.PasswordHash = encrypted.PasswordHash

                // asignando valores 
                currentUser.Nombres = user.Nombres;
                currentUser.Apellidos = user.Apellidos;
                currentUser.NombreUsuario = user.NombreUsuario;
                currentUser.Email = user.Email;
                currentUser.PhoneNumber = user.PhoneNumber;
                currentUser.UpdatedBy = 77;
                currentUser.UpdatedAt = DateTime.Now;

                _context.Entry(currentUser).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                _context.Update<UsuarioEntity>(currentUser);

                _context.SaveChanges();

                return new BaseResponse<string>
                {
                    Response = "Actualizado correctamente",
                    Message = "User was created",
                    StatusCode = StatusCodes.Status200OK,
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<string>
                {
                    Response = default,
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status400BadRequest,
                };
            }
        }

        public bool VefiryPassword(string password, string passwordHash)
        {
            throw new NotImplementedException();
        }
    }
}
