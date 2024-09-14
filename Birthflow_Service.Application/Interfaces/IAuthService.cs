using Birthflow_Application.DTOs;
using Birthflow_Application.DTOs.Auth;
using Birthflow_Service.Application.Models;
using BirthflowService.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Birthflow_Application.DTOs.Auth.UsuarioEntityDto;

namespace BirthflowService.Application.Interfaces
{
    public interface IAuthService
    {
        BaseResponse<UserLoginDto> Login(LoginModel dto);
        BaseResponse<UsuarioEntityDto> Create(UsuarioEntityDto dto);
        BaseResponse<UserLoginDto> Refresh(Tokens tokens);
        BaseResponse<string> ActivateAccount(string token);
    }
}
