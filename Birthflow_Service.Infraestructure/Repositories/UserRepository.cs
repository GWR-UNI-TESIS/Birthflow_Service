using Birthflow_Application.DTOs;
using Birthflow_Application.DTOs.Auth;
using Birthflow_Domain.Interface;
using Birthflow_Service.Infraestructure.DbContexts;
using BirthflowService.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Birthflow_Infraestructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BirthflowDbContext _context;

        public UserRepository(BirthflowDbContext context)
        {
            _context = context;
        }
 
        public async Task<UserEntity?> GetByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<UserEntity?> GetById(Guid userId)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
        }

        public async Task<UserEntity?> GetByUserName(string userName)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserName == userName);
        }

        public async Task<UserEntity> SaveUser(UsuarioEntityDto user)
        {
            try
            {
                var encryptedPassword = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);

                var newUserEntity = new UserEntity()
                {
                    Name = user.Nombres,
                    SecondName = user.Apellidos,
                    UserName = user.NombreUsuario,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
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

                await _context.Users.AddAsync(newUserEntity);

                await _context.SaveChangesAsync();

                _context.SaveChanges();

                return newUserEntity;
            }
            catch (Exception)
            {
                throw;
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
    }
}