using Birthflow_Application.DTOs;
using Birthflow_Application.DTOs.Auth;
using BirthflowService.Application.Interfaces;
using BirthflowService.Domain.DTOs.Partograph;
using BirthflowService.Domain.Entities;
using BirthflowService.Domain.Interface;
using BirthflowService.Infraestructure.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BirthflowService.Application.Services
{
    public class PartographService : IPartographService
    {
        private readonly IConfiguration _configuration;
        private readonly IPartographRepository _partographRepo;
        private readonly IUserTokenService _tokenServices;

        public PartographService(IConfiguration configuration, IPartographRepository partographRepo, IUserTokenService tokenServices)
        {
            _configuration = configuration;
            _partographRepo = partographRepo;
            _tokenServices = tokenServices;
        }

        public async Task<BaseResponse<PartographEntity>> CreatePartograph(PartographDto partographDto)
        {
            try
            {
                Guid userId = _tokenServices.GetUserId();

                var PartographEntity = new PartographEntity {
                    PartographId = Guid.NewGuid(),
                    Name = partographDto.Name,
                    RecordName = partographDto.RecordName,
                    Date = partographDto.Date,
                    Observation = partographDto.Observation,
                    WorkTime = partographDto.WorkTime,
                    IsDelete = false,
                    CreatedAt = DateTime.Now,
                    CreatedBy = userId,
                };

                var result = await _partographRepo.CreatePartograph(PartographEntity);

                return new BaseResponse<PartographEntity>
                {
                    Message = "Ingresado correctamente",
                    Response = result,
                    StatusCode = StatusCodes.Status200OK,
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<PartographEntity>
                {
                    Response = null!,
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status400BadRequest,
                };
            }
        }

        public async Task<BaseResponse<IEnumerable<PartographEntity>>> GetPartographs(Guid userId)
        {
            try
            {
                var result = await _partographRepo.GetPartographs(userId);

                return new BaseResponse<IEnumerable<PartographEntity>>
                {
                    Message = "Ingresado correctamente",
                    Response = result,
                    StatusCode = StatusCodes.Status200OK,
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<PartographEntity>>
                {
                    Response = null!,
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status400BadRequest,
                };
            }
        }

        public async Task<BaseResponse<PartographEntity>> GetPartograph(Guid partographId)
        {
            try
            {
                var result =  await _partographRepo.GetPartograph(partographId);
                return new BaseResponse<PartographEntity>
                {
                    Message = "Ingresado correctamente",
                    Response = result,
                    StatusCode = StatusCodes.Status200OK,
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<PartographEntity>
                {
                    Response = null!,
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status400BadRequest,
                };
            }
        }

        public async Task<BaseResponse<CervicalDilationEntity>> CreateCervicalDilation(CervicalDilationDto cervicalDilationDto)
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

                var result = await _partographRepo.CreateCervicalDilation(cervicalDilationEntity);

                return new BaseResponse<CervicalDilationEntity>
                {
                    Response = result,
                    Message = "La dilatacion cervical ha sido creada correctamente",
                    StatusCode = StatusCodes.Status200OK,
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<CervicalDilationEntity>
                {
                    Response = null!,
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status400BadRequest,
                };
            }
        }

        public async Task<BaseResponse<CervicalDilationEntity>> DeleteCervicalDilation(CervicalDilationDto cervicalDilationDto)
        {
            try
            {
               Guid userId = _tokenServices.GetUserId();

                var result = await _partographRepo.DeleteCervicalDilation(cervicalDilationDto.Id, userId);

                return new BaseResponse<CervicalDilationEntity>
                {
                    Response = result,
                    Message = "La dilatacion cervical ha sido creada eliminada",
                    StatusCode = StatusCodes.Status200OK,
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<CervicalDilationEntity>
                {
                    Response = null!,
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status400BadRequest,
                };
            }
        }

        public async Task<BaseResponse<IEnumerable<CervicalDilationEntity>>> GetCervicalDilations(Guid partographId)
        {
            try
            {
                var result = await _partographRepo.GetCervicalDilations(partographId);

                return new BaseResponse<IEnumerable<CervicalDilationEntity>>
                {
                    Response = result,
                    Message = "La dilatacion cervical ha sido creada correctamente",
                    StatusCode = StatusCodes.Status200OK,
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<CervicalDilationEntity>>
                {
                    Response = null!,
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status400BadRequest,
                };
            }
        }

        public async Task<BaseResponse<CervicalDilationEntity>> UpdateCervicalDilation(CervicalDilationDto cervicalDilationDto)
        {
            try
            {
                if(cervicalDilationDto.Id == null)
                    return new BaseResponse<CervicalDilationEntity>
                    {
                        Response = null!,
                        Message = "ID no encontrado",
                        StatusCode = StatusCodes.Status400BadRequest,
                    };

                var cerivicalDilation = await _partographRepo.GetCervicalDilation((long)cervicalDilationDto.Id!);
                if (cerivicalDilation == null)
                {
                    return new BaseResponse<CervicalDilationEntity>
                    {
                        Response = null!,
                        Message = "Dilatacion cervical no fue encontrada",
                        StatusCode = StatusCodes.Status200OK,
                    };
                }
                else
                {
                    cerivicalDilation.Hour = cervicalDilationDto.Hour;
                    cerivicalDilation.Value = cervicalDilationDto.Value;
                    cerivicalDilation.RemOrRam = cerivicalDilation.RemOrRam;
                    cerivicalDilation.UpdateBy = cervicalDilationDto.UserId;
                    cerivicalDilation.UpdateAt = DateTime.Now;

                    var result = await _partographRepo.UpdateCervicalDilation(cerivicalDilation);

                    return new BaseResponse<CervicalDilationEntity>
                    {
                        Response = result,
                        Message = "Dilatacion cervical no fue encontrada",
                        StatusCode = StatusCodes.Status200OK,
                    };
                }
            }
            catch (Exception ex)
            {
                return new BaseResponse<CervicalDilationEntity>
                {
                    Response = null!,
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status400BadRequest,
                };
            }
        }

        public async Task<BaseResponse<IEnumerable<PresentationPositionVarietyEntity>>> GetAllPresentationPositionVariety()
        {
            try
            {
                var result = await _partographRepo.GetAllPresentationPositionVariety();

                return new BaseResponse<IEnumerable<PresentationPositionVarietyEntity>>
                {
                    Response = result,
                    Message = "Dilatacion cervical no fue encontrada",
                    StatusCode = StatusCodes.Status200OK,
                };
            }
            catch(Exception ex)
            {
                return new BaseResponse<IEnumerable<PresentationPositionVarietyEntity>>
                {
                    Response = null!,
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status400BadRequest,
                };
            }
        }

        public async Task<BaseResponse<IEnumerable<PresentationPositionVarietyEntity>>> GetPresentationPositionVarietyByParthographId(Guid parthographId)
        {
            try
            {
                var result = await _partographRepo.GetPresentationPositionVarietyByParthographId(parthographId);

                return new BaseResponse<IEnumerable<PresentationPositionVarietyEntity>>
                {
                    Response = result,
                    Message = "Dilatacion cervical no fue encontrada",
                    StatusCode = StatusCodes.Status200OK,
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<PresentationPositionVarietyEntity>>
                {
                    Response = null!,
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status400BadRequest,
                };
            }
        }

        public async Task< BaseResponse<PresentationPositionVarietyEntity>> CreatePresentationPositionVariety(PresentationPositionVarietyDto presentationDto)
        {
            try
            {
                Guid userId = _tokenServices.GetUserId();
                var entity = presentationDto.ConvertPresentationPositionVarietyDto_Entity();
                DateTime CreatedAt = DateTime.Now;

                entity.CreateAt = CreatedAt;
                entity.CreatedBy = userId;
                entity.Time = CreatedAt;
                entity.IsDelete = false;
                entity.UpdateAt = null;
                entity.DeleteAt = null;
                entity.UpdateBy = null;
                entity.DeletedBy = null;

                var result = await _partographRepo.CreatePresentationPositionVariety(entity);

                return new BaseResponse<PresentationPositionVarietyEntity>
                {
                    Message = "Creacion de variedad de posicion de la presentacion",
                    Response = result,
                    StatusCode = StatusCodes.Status200OK,
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<PresentationPositionVarietyEntity>
                {
                    Response = null!,
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status400BadRequest,
                };
            }
          
        }

        public async Task<BaseResponse<PresentationPositionVarietyEntity>> UpdatePresentationPositionVariety(PresentationPositionVarietyDto presentationDto)
        {
            try
            {
                var isExistedPresentatation = await _partographRepo.GetPresentationPositionVarietyById(presentationDto.Id);

                if (isExistedPresentatation is null)
                {
                    return new BaseResponse<PresentationPositionVarietyEntity>
                    {
                        Message = "Not found",
                        Response = { },
                        StatusCode = StatusCodes.Status400BadRequest,
                    };
                }

                Guid userId = _tokenServices.GetUserId();

                isExistedPresentatation.HodgePlane = presentationDto.HodgePlane;
                isExistedPresentatation.Position = presentationDto.Position;
                isExistedPresentatation.UpdateAt = DateTime.Now;
                isExistedPresentatation.UpdateBy = userId;

                var result = await _partographRepo.UpdatePresentationPositionVariety(isExistedPresentatation);

                return new BaseResponse<PresentationPositionVarietyEntity>
                {
                    Message = "Modificando de variedad de posicion de la presentacion",
                    Response = result,
                    StatusCode = StatusCodes.Status200OK,
                };
            }
            catch (Exception ex) 
            {
                return new BaseResponse<PresentationPositionVarietyEntity>
                {
                    Response = null!,
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status400BadRequest,
                };
            }
        }

        public async Task<BaseResponse<PresentationPositionVarietyEntity>> DeletePresentationPositionVariety(PresentationPositionVarietyDto presentationDto)
        {
            try
            {
                var isExistedPresentatation = await _partographRepo.GetPresentationPositionVarietyById(presentationDto.Id);

                if (isExistedPresentatation is null)
                {
                    return new BaseResponse<PresentationPositionVarietyEntity>
                    {
                        Message = "Not found",
                        Response = { },
                        StatusCode = StatusCodes.Status400BadRequest,
                    };
                }

                Guid userId = _tokenServices.GetUserId();

                isExistedPresentatation.DeleteAt = DateTime.Now;
                isExistedPresentatation.DeletedBy = userId;

                var result = await _partographRepo.UpdatePresentationPositionVariety(isExistedPresentatation);

                return new BaseResponse<PresentationPositionVarietyEntity>
                {
                    Message = "Modificando de variedad de posicion de la presentacion",
                    Response = result,
                    StatusCode = StatusCodes.Status200OK,
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<PresentationPositionVarietyEntity>
                {
                    Response = null!,
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status400BadRequest,
                };
            }
           
        }


        public async Task<BaseResponse<MedicalSurveillanceTableEntity>> GetMedicalSurveillanceTableById(int medicalId)
        {
            try 
            {
                var result = await _partographRepo.GetMedicalSurveillanceTablesById(medicalId);

                return new BaseResponse<MedicalSurveillanceTableEntity>
                {
                    Message = "Modificando de variedad de posicion de la presentacion",
                    Response = result,
                    StatusCode = StatusCodes.Status200OK,
                };
            }
            catch (Exception ex) 
            {
                return new BaseResponse<MedicalSurveillanceTableEntity>
                {
                    Response = null!,
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status400BadRequest,
                };
            }
        }

        public async Task<BaseResponse<IEnumerable<MedicalSurveillanceTableEntity>>> GetMedicalSurveillanceTableByParthographId(Guid medicalId)
        {
            try
            {
                var result = await _partographRepo.GetMedicalSurveillanceTablesByParthographId(medicalId);

                return new BaseResponse<IEnumerable<MedicalSurveillanceTableEntity>>
                {
                    Message = "Modificando de variedad de posicion de la presentacion",
                    Response = result,
                    StatusCode = StatusCodes.Status200OK,
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<MedicalSurveillanceTableEntity>>
                {
                    Response = null!,
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status400BadRequest,
                };
            }
        }

        public async Task<BaseResponse<MedicalSurveillanceTableEntity>> CreateMedicalSurveillanceTable(MedicalSurveillanceTableDTO medicalDto)
        {
            try
            {
                Guid userId = _tokenServices.GetUserId();
                var entity = medicalDto.ConvertMedicalSurveillanceTableDto_Entity();

                entity.Time = DateTime.Now;
                entity.IsDelete = false;
                entity.CreateAt = DateTime.Now;
                entity.CreatedBy = userId;
                entity.UpdateAt = null;
                entity.UpdateBy = null;
                entity.DeleteAt = null;
                entity.DeletedBy = null;

                var result = await _partographRepo.CreateMedicalSurveillanceTable(entity);

                return new BaseResponse<MedicalSurveillanceTableEntity>
                {
                    Message = "Elemento de la tabla de vigilanca guardado correctamente",
                    Response = result,
                    StatusCode = StatusCodes.Status200OK,
                };
            } catch (Exception ex)
            {
                return new BaseResponse<MedicalSurveillanceTableEntity>
                {
                    Response = null!,
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status400BadRequest,
                };
            }
        }

        public async Task<BaseResponse<MedicalSurveillanceTableEntity>> UpdateMedicalSurveillanceTable(MedicalSurveillanceTableDTO medicalDto)
        {
            try
            {
                var isExistedMedical = await _partographRepo.GetMedicalSurveillanceTablesById(medicalDto.Id);

                if (isExistedMedical is null)
                {
                    return new BaseResponse<MedicalSurveillanceTableEntity>
                    {
                        Message = "Not found",
                        Response = { },
                        StatusCode = StatusCodes.Status400BadRequest
                    };
                }

                Guid userId = _tokenServices.GetUserId();

                isExistedMedical.Letter = medicalDto.Letter;
                isExistedMedical.MaternalPosition = medicalDto.MaternalPosition;
                isExistedMedical.ArterialPressure = medicalDto.ArterialPressure;
                isExistedMedical.MaternalPulse = medicalDto.MaternalPulse;
                isExistedMedical.FetalHeartRate = medicalDto.FetalHeartRate;
                isExistedMedical.ContractionsDuration = medicalDto.ContractionsDuration;
                isExistedMedical.FrequencyContractions = medicalDto.FrequencyContractions;
                isExistedMedical.Pain = medicalDto.Pain;
                isExistedMedical.UpdateAt = DateTime.Now;
                isExistedMedical.UpdateBy = userId;

                var result =await _partographRepo.UpdateMedicalSurveillanceTable(isExistedMedical);

                return new BaseResponse<MedicalSurveillanceTableEntity>
                {
                    Message = "Modificado correctamente",
                    Response = result,
                    StatusCode = StatusCodes.Status200OK,
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<MedicalSurveillanceTableEntity>
                {
                    Response = null!,
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status400BadRequest,
                };
            }
        }

        public async Task<BaseResponse<MedicalSurveillanceTableEntity>> DeleteMedicalSurveillanceTable(MedicalSurveillanceTableDTO medicalDto)
        {
            try
            {
                var isExistedMedical = await _partographRepo.GetMedicalSurveillanceTablesById(medicalDto.Id);

                if (isExistedMedical is null)
                {
                    return new BaseResponse<MedicalSurveillanceTableEntity>
                    {
                        Message = "Not found",
                        Response = { },
                        StatusCode = StatusCodes.Status400BadRequest,
                    };
                }

                Guid userId = _tokenServices.GetUserId();

                isExistedMedical.IsDelete = true;
                isExistedMedical.DeleteAt = DateTime.Now;
                isExistedMedical.DeletedBy = userId;

                var result = await _partographRepo.UpdateMedicalSurveillanceTable(isExistedMedical);

                return new BaseResponse<MedicalSurveillanceTableEntity>
                {
                    Message = "Eliminado correctamente",
                    Response = result,
                    StatusCode = StatusCodes.Status200OK,
                };

            }
            catch (Exception ex) 
            {
                return new BaseResponse<MedicalSurveillanceTableEntity>
                {
                    Response = null!,
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status400BadRequest,
                };
            }
        }

        public async Task<BaseResponse<PartographStateEntity>> UpdatePartographState(PartographStateEntity partographStateDto)
        {
            try
            {

                Guid userId = _tokenServices.GetUserId();

                var response = await _partographRepo.GetPartographStateByUser(partographStateDto.PartographId, userId);

                if (response == null)
                    return new BaseResponse<PartographStateEntity>
                    {
                        Response = null!,
                        Message = "No encontrado",
                        StatusCode = StatusCodes.Status400BadRequest,
                    };

                response.IsAchived = partographStateDto.IsAchived;
                response.Set = partographStateDto.Set;
                response.Silenced = partographStateDto.Silenced;
                response.Favorite = partographStateDto.Favorite;

                var result = await _partographRepo.UpdatePartographState(response);


                return new BaseResponse<PartographStateEntity>
                {
                    Message = "Modificado correctamente",
                    Response = result,
                    StatusCode = StatusCodes.Status200OK,
                };

            }
            catch (Exception ex)
            {
                return new BaseResponse<PartographStateEntity>
                {
                    Response = null!,
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status400BadRequest,
                };
            }
        }
    }
}