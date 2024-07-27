using Birthflow_Application.DTOs;
using Birthflow_Domain.DTOs.Partographs;
using Birthflow_Domain.Entities;
using Birthflow_Domain.Interface;
using Birthflow_Infraestructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birthflow_Application.Services
{
    public class PartographServices : IPartographServices
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<PartographServices> _logger;
        private readonly PartographRepository _partographRepo;

        public PartographServices(IConfiguration configuration, PartographRepository _partographRepo)
        {
            _configuration = configuration;
            this._partographRepo = _partographRepo;
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
    }
}
