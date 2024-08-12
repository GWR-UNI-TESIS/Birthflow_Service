using Birthflow_Application.DTOs;
using BirthflowService.Application.Interfaces;
using BirthflowService.Domain.DTOs.Partograph;
using BirthflowService.Domain.Entities;
using BirthflowService.Infraestructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthflowService.Application.Services
{
    public class PartographService : IPartographService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<PartographService> _logger;
        private readonly PartographRepository _partographRepo;

        public PartographService(IConfiguration configuration, PartographRepository partographRepo)
        {
            _configuration = configuration;
            _partographRepo = partographRepo;
        }

        public BaseResponse<PartographEntity> CreatePartograph(PartographDto partographDto)
        {
            try
            {
                return _partographRepo.CreatePartograph(partographDto);
            }
            catch (Exception ex)
            {
                return new BaseResponse<PartographEntity>
                {
                    Response = null,
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status400BadRequest,
                };
            }
        }

        public BaseResponse<IEnumerable<PartographEntity>> GetPartograph(Guid userId)
        {
            try
            {
                return _partographRepo.GetPartograph(userId);
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<PartographEntity>>
                {
                    Response = null,
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status400BadRequest,
                };
            }
        }

        public BaseResponse<CervicalDilationEntity> CreateCervicalDilation(CervicalDilationDto cervicalDilationDto)
        {
            try
            {
                return _partographRepo.CreateCervicalDilation(cervicalDilationDto);
            }
            catch (Exception ex)
            {
                return new BaseResponse<CervicalDilationEntity>
                {
                    Response = null,
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status400BadRequest,
                };
            }
        }


        public BaseResponse<CervicalDilationEntity> DeleteCervicalDilation(int? id, Guid? userId)
        {
            try
            {
                return _partographRepo.DeleteCervicalDilation(id, userId);
            }
            catch (Exception ex)
            {
                return new BaseResponse<CervicalDilationEntity>
                {
                    Response = null,
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status400BadRequest,
                };
            }
        }

        public BaseResponse<IEnumerable<CervicalDilationEntity>> GetCervicalDilations(Guid partographId)
        {
            try
            {
                return _partographRepo.GetCervicalDilations(partographId);
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<CervicalDilationEntity>>
                {
                    Response = null,
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status400BadRequest,
                };
            }
        }

        public BaseResponse<CervicalDilationEntity> UpdateCervicalDilation(CervicalDilationDto cervicalDilationDto)
        {
            try
            {
                return _partographRepo.UpdateCervicalDilation(cervicalDilationDto);
            }
            catch (Exception ex)
            {
                return new BaseResponse<CervicalDilationEntity>
                {
                    Response = null,
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status400BadRequest,
                };
            }
        }
    }
}
