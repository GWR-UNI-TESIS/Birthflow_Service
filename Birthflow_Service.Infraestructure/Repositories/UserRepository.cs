using Birthflow_Application.DTOs;
using Birthflow_Application.DTOs.Auth;
using Birthflow_Domain.Interface;
using Birthflow_Service.Infraestructure.DbContexts;
using BirthflowMicroServices.Domain.Models;
using Microsoft.AspNetCore.Http;

using static Birthflow_Application.DTOs.Auth.UsuarioEntityDto;

namespace Birthflow_Infraestructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BirthflowDbContext _context;

        public UserRepository(BirthflowDbContext context)
        {
          _context = context;
        }

        public string ChangePassword(UserEntity user, string newPassword)
        {
            throw new NotImplementedException();
        }

        public string EncryptedPassword(UserDto request)
        {
            UserEntity user = new UserEntity();
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            return passwordHash;
        }

        public UserEntity? GetByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }

        public UserEntity? GetById(Guid userId)
        {
            return _context.Users.FirstOrDefault(u => u.Id == userId);
        }

        public UserEntity? GetByUserName(string userName)
        {
            return _context.Users.FirstOrDefault(u => u.UserName == userName);
        }
        public BaseResponse<string> RestartPassword(UserEntity user, string newPassword)
        {
            throw new NotImplementedException();
        }

        public BaseResponse<UsuarioEntityDto> SaveUser(UsuarioEntityDto user)
        {
            try
            {
                var encrypted = EncryptedPassword(new UserDto { Email = user.NombreUsuario!, Password = user.PasswordHash! });

                var newUserEntity = new UserEntity()
                {
                    Name = user.Nombres,
                    SecondName = user.Apellidos,
                    UserName = user.NombreUsuario,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    PasswordHash = encrypted,
                    IsDelete = false,
                    IsActive = true,
                    CreatedAt = DateTime.Now,
                    CreatedBy = 1,
                    UpdatedAt = null,
                    UpdatedBy = null,
                    DeletedAt = null,
                    DeletedBy = null
                };

                _context.Entry(newUserEntity).State = Microsoft.EntityFrameworkCore.EntityState.Added;

                _context.Add<UserEntity>(newUserEntity);

                _context.SaveChanges();

                var dto = new UsuarioEntityDto()
                {
                    Id = user.Id,
                    Nombres = newUserEntity.Name,
                    Apellidos = newUserEntity.SecondName,
                    NombreUsuario = newUserEntity.UserName,
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

        public BaseResponse<string> UpdateUser(UsuarioEntityDto user, UserEntity currentUser)
        {
            try
            {
                var existEmail = GetByEmail(user.Email);
                if (existEmail is not null && user.Email != currentUser.Email)
                    return new BaseResponse<string>
                    {
                        Response = user.Email,
                        Message = "Email already exist",
                        StatusCode = StatusCodes.Status400BadRequest,
                    };

                var existUsername = GetByUserName(user.NombreUsuario);
                if (existUsername is not null && user.NombreUsuario != currentUser.UserName)
                    return new BaseResponse<string>
                    {
                        Response = user.NombreUsuario,
                        Message = "user already exist",
                        StatusCode = StatusCodes.Status400BadRequest,
                    };

                //var encrypted = EncryptedPassword(new UserDto { UserName = user.UserName, Password = user.PasswordHash });

                //user.PasswordHash = encrypted.PasswordHash

                // asignando valores 
                currentUser.Name = user.Nombres;
                currentUser.SecondName = user.Apellidos;
                currentUser.UserName = user.NombreUsuario;
                currentUser.Email = user.Email;
                currentUser.PhoneNumber = user.PhoneNumber;
                currentUser.UpdatedBy = 77;
                currentUser.UpdatedAt = DateTime.Now;

                _context.Entry(currentUser).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                _context.Update<UserEntity>(currentUser);

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
            return BCrypt.Net.BCrypt.Verify(password, passwordHash);
        }
    }
}
