using Birthflow_Application.DTOs;
using Birthflow_Domain.DTOs.Partographs;
using Birthflow_Domain.Entities;
using Birthflow_Domain.Interface;
using Birthflow_Service.Infraestructure.DbContexts;
using Microsoft.AspNetCore.Http;

namespace Birthflow_Infraestructure.Repositories
{
    public class PartographRepository : IPartographServices
    {
        private readonly BirthflowDbContext _context;

        public PartographRepository(BirthflowDbContext _context)
        {
            this._context = _context;
        }

        public BaseResponse<PartographEntity> CreatePartograph(PartographDto partographDto)
        {
            try
            {
                var partographEntity = new PartographEntity()
                {
                    PartographId = Guid.NewGuid(),
                    Name = partographDto.Name,
                    RecordName = partographDto.RecordName,
                    Date = partographDto.Date,
                    Observation = partographDto.Observation,
                    IsDelete = false,
                    CreatedAt = DateTime.Now,
                    CreatedBy = partographDto.CreatedBy,
                    DeletedAt = null,
                    DeletedBy = null,
                    WorkTime = partographDto.WorkTime,
                };

                _context.Partographs.Add(partographEntity);

                _context.SaveChanges();

                return new BaseResponse<PartographEntity>
                {
                    Response = partographEntity,
                    Message = "El partograma ha sido creado correctamente",
                    StatusCode = StatusCodes.Status200OK,
                };
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
                var result = _context.Partographs.Where((e) => e.CreatedBy == userId).ToList();

                if (result.Count == 0)
                    return new BaseResponse<IEnumerable<PartographEntity>>
                    {
                        Response = null,
                        Message = "No existen partogramas",
                        StatusCode = StatusCodes.Status200OK,
                    };
                else
                    return new BaseResponse<IEnumerable<PartographEntity>>
                    {
                        Response = result,
                        Message = "Partogramas resueltos",
                        StatusCode = StatusCodes.Status200OK,
                    };
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