using Birthflow_Application.DTOs;
using Birthflow_Service.Infraestructure.DbContexts;
using BirthflowService.Domain.DTOs.Partograph;
using BirthflowService.Domain.Entities;
using BirthflowService.Domain.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BirthflowService.Infraestructure.Repositories
{
    public class PartographRepository : IPartographRepository
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

        public BaseResponse<IEnumerable<PartographEntity>> GetPartographs(Guid userId)
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

        public BaseResponse<PartographEntity> GetPartograph(Guid partographId)
        {
            try
            {
                var result = _context.Partographs
                  .Include(p => p.CervicalDilationEntities)
                  .FirstOrDefault(p => p.PartographId == partographId);

                if (result == null)
                    return new BaseResponse<PartographEntity>
                    {
                        Response = null,
                        Message = "Partograma no encontrado",
                        StatusCode = StatusCodes.Status200OK,
                    };

                return new BaseResponse<PartographEntity>
                {
                    Response = result,
                    Message = "Partograma encontrado",
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

        public BaseResponse<CervicalDilationEntity> CreateCervicalDilation(CervicalDilationDto cervicalDilationDto)
        {
            try
            {
                var cervicalDilationEntity = new CervicalDilationEntity
                {
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
                _context.Add(cervicalDilationEntity);

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
                        Response = { },
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
                    Response = { },
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

        //Metodos de variedad de posicion fetal - plano de hodge
        public BaseResponse<List<PresentationPositionVarietyEntity>> GetAllPresentationPositionVariety()
        {
            var result = _context.PresentationPositionVarietyEntities.ToList();

            if (result is null)
            {
                return new BaseResponse<List<PresentationPositionVarietyEntity>>
                {
                    Message = "Not found",
                    Response = new List<PresentationPositionVarietyEntity>(),
                    StatusCode = StatusCodes.Status200OK
                };
            }

            return new BaseResponse<List<PresentationPositionVarietyEntity>>
            {
                Message = "Get All Presentation Positions",
                Response = result,
                StatusCode = StatusCodes.Status200OK
            };
        }

        public BaseResponse<List<PresentationPositionVarietyEntity>> GetPresentationPositionVarietyByParthographId(Guid parthographId)
        {
            var result = _context.PresentationPositionVarietyEntities.Where(ppv => ppv.PartographId == parthographId).ToList();

            if (result is null)
            {
                return new BaseResponse<List<PresentationPositionVarietyEntity>>
                {
                    Message = "Not found",
                    Response = null,
                    StatusCode = StatusCodes.Status200OK
                };
            }

            return new BaseResponse<List<PresentationPositionVarietyEntity>>
            {
                Message = "Get presentation position by parthographId",
                Response = result,
                StatusCode = StatusCodes.Status200OK
            };
        }

        public BaseResponse<PresentationPositionVarietyEntity> GetPresentationPositionVarietyById(int presentationId)
        {
            var result = _context.PresentationPositionVarietyEntities.FirstOrDefault(ppv => ppv.Id == presentationId);

            if (result is null)
            {
                return new BaseResponse<PresentationPositionVarietyEntity>
                {
                    Message = "Not found",
                    Response = null,
                    StatusCode = StatusCodes.Status200OK
                };
            }

            return new BaseResponse<PresentationPositionVarietyEntity>
            {
                Message = "Get presentation position by parthographId",
                Response = result,
                StatusCode = StatusCodes.Status200OK
            };
        }

        public BaseResponse<PresentationPositionVarietyEntity> CreatePresentationPositionVariety(PresentationPositionVarietyEntity presentation)
        {
            try
            {
                _context.PresentationPositionVarietyEntities.Add(presentation);
                _context.SaveChanges();

                return new BaseResponse<PresentationPositionVarietyEntity>
                {
                    Message = "Inserted correctly",
                    Response = presentation,
                    StatusCode = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<PresentationPositionVarietyEntity>
                {
                    Message = $"ERROR: {ex.Message}",
                    Response = presentation,
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
        }

        public BaseResponse<PresentationPositionVarietyEntity> UpdatePresentationPositionVariety(PresentationPositionVarietyEntity presentation)
        {
            try
            {
                _context.PresentationPositionVarietyEntities.Update(presentation);
                _context.SaveChanges();

                return new BaseResponse<PresentationPositionVarietyEntity>
                {
                    Message = "Updated correctly",
                    Response = presentation,
                    StatusCode = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<PresentationPositionVarietyEntity>
                {
                    Message = $"ERROR: {ex.Message}",
                    Response = presentation,
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
        }

        public BaseResponse<List<MedicalSurveillanceTableEntity>> GetAllMedicalSurveillanceTables()
        {
            var result = _context.MedicalSurveillanceTables.ToList();

            if (result is null)
            {
                return new BaseResponse<List<MedicalSurveillanceTableEntity>>
                {
                    Message = "Get all MedicalSurveillanceTableEntity",
                    Response = new List<MedicalSurveillanceTableEntity>(),
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }

            return new BaseResponse<List<MedicalSurveillanceTableEntity>>
            {
                Message = "Get all MedicalSurveillanceTableEntity",
                Response = result,
                StatusCode = StatusCodes.Status200OK
            };
        }

        public BaseResponse<MedicalSurveillanceTableEntity> GetMedicalSurveillanceTablesById(int medicalId)
        {
            var result = _context.MedicalSurveillanceTables.FirstOrDefault(mst => mst.Id == medicalId);

            if (result is null)
            {
                return new BaseResponse<MedicalSurveillanceTableEntity>
                {
                    Message = "Get all MedicalSurveillanceTableEntity",
                    Response = null,
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }

            return new BaseResponse<MedicalSurveillanceTableEntity>
            {
                Message = "Get all MedicalSurveillanceTableEntity",
                Response = result,
                StatusCode = StatusCodes.Status200OK
            };
        }

        public BaseResponse<List<MedicalSurveillanceTableEntity>> GetMedicalSurveillanceTablesByParthographId(Guid parthographId)
        {
            var result = _context.MedicalSurveillanceTables.Where(mst => mst.PartographId == parthographId).ToList();

            if (result is null)
            {
                return new BaseResponse<List<MedicalSurveillanceTableEntity>>
                {
                    Message = "Get all MedicalSurveillanceTableEntity",
                    Response = null,
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }

            return new BaseResponse<List<MedicalSurveillanceTableEntity>>
            {
                Message = "Get all MedicalSurveillanceTableEntity",
                Response = result,
                StatusCode = StatusCodes.Status200OK
            };
        }

        public BaseResponse<MedicalSurveillanceTableEntity> CreateMedicalSurveillanceTable(MedicalSurveillanceTableEntity medical)
        {
            try
            {
                _context.MedicalSurveillanceTables.Add(medical);
                _context.SaveChanges();

                return new BaseResponse<MedicalSurveillanceTableEntity>
                {
                    Message = "Inserted correctly",
                    Response = medical,
                    StatusCode = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<MedicalSurveillanceTableEntity>
                {
                    Message = $"ERROR: {ex.Message}",
                    Response = medical,
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
        }

        public BaseResponse<MedicalSurveillanceTableEntity> UpdateMedicalSurveillanceTable(MedicalSurveillanceTableEntity medical)
        {
            try
            {
                _context.MedicalSurveillanceTables.Update(medical);
                _context.SaveChanges();

                return new BaseResponse<MedicalSurveillanceTableEntity>
                {
                    Message = "Update correctly",
                    Response = medical,
                    StatusCode = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<MedicalSurveillanceTableEntity>
                {
                    Message = $"ERROR: {ex.Message}",
                    Response = medical,
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
        }
    }
}