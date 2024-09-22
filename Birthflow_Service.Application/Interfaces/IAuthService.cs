using Birthflow_Application.DTOs;
using Birthflow_Application.DTOs.Auth;
using Birthflow_Service.Application.Models;
using BirthflowService.Application.Models;
using BirthflowService.Domain.Entities;
using static Birthflow_Application.DTOs.Auth.UsuarioEntityDto;

namespace BirthflowService.Application.Interfaces
{
    public interface IAuthService
    {
        Task<BaseResponse<UserLoginDto>> Login(LoginModel dto);
        Task<BaseResponse<UsuarioEntityDto>> Create(UsuarioEntityDto dto);
        Task<BaseResponse<UserLoginDto>> Refresh(Tokens tokens);
        Task<BaseResponse<string>> ActivateAccount(string token);
    }
}
