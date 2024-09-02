using Birthflow_Application.DTOs;
using Birthflow_Application.DTOs.Auth;
using BirthflowMicroServices.Domain.Models;
using BirthflowService.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthflowService.Application.Services
{
    public class UserService : IUserService
    {/*
        public UserEntity? GetByEmail(string email)
        {
            var result = _authRepo.GetByEmail(email);

            return result;
        }

        public UserEntity? GetById(Guid userId)
        {
            var result = _authRepo.GetById(userId);

            return result;
        }

        public UserEntity? GetByUserName(string userName)
        {
            var result = _authRepo.GetByUserName(userName);

            return result;
        }

        public BaseResponse<UsuarioEntityDto> SaveUser(UsuarioEntityDto user)
        {
            var result = _authRepo.SaveUser(user);

            return result;
        }

        */
        public BaseResponse<string> UpdateUser(UsuarioEntityDto user)
        {
           // var result = .UpdateUser(user);

            return null;
        }

    }
}
