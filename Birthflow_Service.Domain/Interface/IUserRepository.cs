using Birthflow_Application.DTOs;
using Birthflow_Application.DTOs.Auth;
using BirthflowService.Domain.Entities;

namespace Birthflow_Domain.Interface
{
    public interface IUserRepository
    {
        Task<UserEntity> SaveUser(UsuarioEntityDto user);
        Task<UserEntity?> GetById(Guid userId);
        Task<UserEntity?> GetByUserName(string userName);
        Task<UserEntity?> GetByEmail(string email);
        BaseResponse<string> UpdateUser(UsuarioEntityDto user, UserEntity currentUser);
    }
}
