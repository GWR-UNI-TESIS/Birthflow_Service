using Birthflow_Application.DTOs;
using Birthflow_Application.DTOs.Auth;
using BirthflowMicroServices.Domain.Models;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Birthflow_Application.DTOs.Auth.UsuarioEntityDto;

namespace Birthflow_Domain.Interface
{
    public interface IAuthServices
    {
        string CreateToken(UsuarioEntity user);
        string EncryptedPassword(UsuarioEntityDto.UserDto request);
        BaseResponse<UsuarioEntity> SaveUser(UsuarioEntityDto user);
        UsuarioEntity? GetById(Guid userId);
        UsuarioEntity? GetByUserName(string userName);
        UsuarioEntity? GetByEmail(string email);
        string ChangePassword(UsuarioEntity user, string newPassword);
        bool VefiryPassword(string password, string passwordHash);
        BaseResponse<string> UpdateUser(UsuarioEntityDto user, UsuarioEntity currentUser);
        BaseResponse<string> RestartPassword(UsuarioEntity user, string newPassword);

    }
}
