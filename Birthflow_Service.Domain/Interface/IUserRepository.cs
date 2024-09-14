using Birthflow_Application.DTOs;
using Birthflow_Application.DTOs.Auth;
using BirthflowService.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Birthflow_Application.DTOs.Auth.UsuarioEntityDto;

namespace Birthflow_Domain.Interface
{
    public interface IUserRepository
    {
        string EncryptedPassword(UsuarioEntityDto.UserDto request);
        BaseResponse<UsuarioEntityDto> SaveUser(UsuarioEntityDto user);
        UserEntity? GetById(Guid userId);
        UserEntity? GetByUserName(string userName);
        UserEntity? GetByEmail(string email);
        string ChangePassword(UserEntity user, string newPassword);
        BaseResponse<string> UpdateUser(UsuarioEntityDto user, UserEntity currentUser);
        BaseResponse<string> RestartPassword(UserEntity user, string newPassword);
        bool VefiryPassword(string password, string passwordHash);

    }
}
