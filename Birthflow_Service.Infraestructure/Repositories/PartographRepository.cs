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

        public BaseResponse<CervicalDilationEntity> CreateCervicalDilation(CervicalDilationDto cervicalDilationDto)
        {
            try
            {
                var cervicalDilationEntity = new CervicalDilationEntity { 
                    PartographId = cervicalDilationDto.PartographId, 
                    Hour = cervicalDilationDto.Hour,
                    RemOrRam = cervicalDilationDto.RemOrRam, 
                    Value = cervicalDilationDto.Value,
                    IsDelete = false,
                    CreateAt = DateTime.Now,
                    CreatedBy = cervicalDilationDto.UserId,
                    UpdateAt = null, 
                    UpdateBy = null, 
                    DeleteAt = null, 
                    DeleteBy = null,
                };
                _context.CervicalDilations.Add(cervicalDilationEntity);

                _context.SaveChanges();
                return new BaseResponse<CervicalDilationEntity>
                {
                    Response = cervicalDilationEntity,
                    Message = "Dilatacion cervical guardada correctamente",
                    StatusCode = StatusCodes.Status200OK,
                };
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
                var cerivicalDilation = _context.CervicalDilations.Find(id);
                if (cerivicalDilation == null)
                {
                    return new BaseResponse<CervicalDilationEntity>
                    {
                        Response = {},
                        Message = "Dilatacion cervical no fueron encontradas",
                        StatusCode = StatusCodes.Status200OK,
                    };
                }
                else
                {
                    cerivicalDilation.IsDelete = true;
                    cerivicalDilation.DeleteBy = userId;
                    cerivicalDilation.DeleteAt = DateTime.Now;
                    _context.SaveChanges();

                    return new BaseResponse<CervicalDilationEntity>
                    {
                        Response = cerivicalDilation,
                        Message = "Dilatacion cervical eliminada correctamente",
                        StatusCode = StatusCodes.Status200OK,
                    };
                }
            }
            catch (Exception ex)
            {
                return new BaseResponse<CervicalDilationEntity>
                {
                    Response = {},
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status400BadRequest,
                };
            }
        }

        public BaseResponse<IEnumerable<CervicalDilationEntity>> GetCervicalDilations(Guid partographId)
        {
            try
            {
                var result = _context.CervicalDilations.Where((e) => e.PartographId == partographId).ToList();

                if (result.Count == 0)
                    return new BaseResponse<IEnumerable<CervicalDilationEntity>>
                    {
                        Response = null,
                        Message = "No existen dilataciones cervicales",
                        StatusCode = StatusCodes.Status200OK,
                    };
                else
                    return new BaseResponse<IEnumerable<CervicalDilationEntity>>
                    {
                        Response = result,
                        Message = "Dilataciones cervicales encontradas",
                        StatusCode = StatusCodes.Status200OK,
                    };
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
                var cerivicalDilation = _context.CervicalDilations.Find(cervicalDilationDto.Id);
                if (cerivicalDilation == null)
                {
                    return new BaseResponse<CervicalDilationEntity>
                    {
                        Response = { },
                        Message = "Dilatacion cervical no fue encontrada",
                        StatusCode = StatusCodes.Status200OK,
                    };
                }
                else
                {
                    cerivicalDilation.Hour = cerivicalDilation.Hour;
                    cerivicalDilation.Value = cervicalDilationDto.Value;
                    cerivicalDilation.RemOrRam = cerivicalDilation.RemOrRam;
                    cerivicalDilation.UpdateBy = cervicalDilationDto.UserId;
                    cerivicalDilation.UpdateAt = DateTime.Now;
                    _context.SaveChanges();

                    return new BaseResponse<CervicalDilationEntity>
                    {
                        Response = cerivicalDilation,
                        Message = "Dilatacion cervical eliminada correctamente",
                        StatusCode = StatusCodes.Status200OK,
                    };
                }
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