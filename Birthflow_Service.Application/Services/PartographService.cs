using Birthflow_Application.DTOs;
using Birthflow_Application.DTOs.Auth;
using BirthflowService.Application.Interfaces;
using BirthflowService.Domain.DTOs.Partograph;
using BirthflowService.Domain.Entities;
using BirthflowService.Domain.Interface;
using BirthflowService.Infraestructure.Utils;
using Microsoft.AspNetCore.Http;
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

        public BaseResponse<PartographEntity> CreatePartograph(PartographDto partographDto)
        {
            try
            {
                if (partographDto is null)
                {
                    return new BaseResponse<PartographEntity>
                    {
                        Response = null,
                        Message = "El modelo es requerido",
                        StatusCode = StatusCodes.Status404NotFound,
                    };
                }
                var result = _partographRepo.CreatePartograph(partographDto);

                if (result.StatusCode == 400)
                {
                    return new BaseResponse<PartographEntity>
                    {
                        Message = result.Message,
                        Response = result.Response,
                        StatusCode = result.StatusCode,
                    };
                }
                return new BaseResponse<PartographEntity>
                {
                    Message = result.Message,
                    Response = result.Response,
                    StatusCode = result.StatusCode,
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
                if (userId == Guid.Empty)
                {
                    return new BaseResponse<IEnumerable<PartographEntity>>
                    {
                        Response = null,
                        Message = "El ID es requerido",
                        StatusCode = StatusCodes.Status404NotFound,
                    };
                }
                return _partographRepo.GetPartographs(userId);
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
                if (partographId == Guid.Empty)
                {
                    return new BaseResponse<PartographEntity>
                    {
                        Response = null,
                        Message = "El ID es requerido",
                        StatusCode = StatusCodes.Status404NotFound,
                    };
                }
                return _partographRepo.GetPartograph(partographId);
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
                if (cervicalDilationDto == null)
                {
                    return new BaseResponse<CervicalDilationEntity>
                    {
                        Response = null,
                        Message = "El body es requerido",
                        StatusCode = StatusCodes.Status404NotFound,
                    };
                }
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

        public BaseResponse<CervicalDilationEntity> DeleteCervicalDilation(CervicalDilationDto cervicalDilationDto)
        {
            try
            {
                if (cervicalDilationDto == null)
                {
                        return new BaseResponse<CervicalDilationEntity>
                    {
                        Response = null,
                        Message = "El body es requerido",
                        StatusCode = StatusCodes.Status404NotFound,
                    };
                }

                Guid userId = _tokenServices.GetUserId();

                return _partographRepo.DeleteCervicalDilation(cervicalDilationDto.Id, userId);
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
                if (partographId == Guid.Empty)
                {
                    return new BaseResponse<IEnumerable<CervicalDilationEntity>>
                    {
                        Response = null,
                        Message = "El ID es requerido",
                        StatusCode = StatusCodes.Status404NotFound,
                    };
                }

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
                if (cervicalDilationDto == null)
                {
                    return new BaseResponse<CervicalDilationEntity>
                    {
                        Response = null,
                        Message = "El body es requerido",
                        StatusCode = StatusCodes.Status404NotFound,
                    };
                }

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

        public BaseResponse<List<PresentationPositionVarietyEntity>> GetAllPresentationPositionVariety()
        {
            var result = _partographRepo.GetAllPresentationPositionVariety();

            return result;
        }

        public BaseResponse<List<PresentationPositionVarietyEntity>> GetPresentationPositionVarietyByParthographId(Guid parthographId)
        {
            var result = _partographRepo.GetPresentationPositionVarietyByParthographId(parthographId);

            return result;
        }

        public BaseResponse<PresentationPositionVarietyDto> CreatePresentationPositionVariety(PresentationPositionVarietyDto presentationDto)
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

            var result = _partographRepo.CreatePresentationPositionVariety(entity);

            if (result.StatusCode == 400)
            {
                return new BaseResponse<PresentationPositionVarietyDto>
                {
                    Message = result.Message,
                    Response = presentationDto,
                    StatusCode = result.StatusCode,
                };
            }
            return new BaseResponse<PresentationPositionVarietyDto>
            {
                Message = result.Message,
                Response = presentationDto,
                StatusCode = result.StatusCode,
            };
        }

        public BaseResponse<PresentationPositionVarietyDto> UpdatePresentationPositionVariety(PresentationPositionVarietyDto presentationDto)
        {
            var isExistedPresentatation = _partographRepo.GetPresentationPositionVarietyById(presentationDto.Id);

            if (isExistedPresentatation.Response is null)
            {
                return new BaseResponse<PresentationPositionVarietyDto>
                {
                    Message = "Not found",
                    Response = presentationDto,
                    StatusCode = StatusCodes.Status400BadRequest,
                };
            }

            Guid userId = _tokenServices.GetUserId();

            isExistedPresentatation.Response.HodgePlane = presentationDto.HodgePlane;
            isExistedPresentatation.Response.Position = presentationDto.Position;
            isExistedPresentatation.Response.UpdateAt = DateTime.Now;
            isExistedPresentatation.Response.UpdateBy = userId;

            var result = _partographRepo.UpdatePresentationPositionVariety(isExistedPresentatation.Response);

            if (result.StatusCode == 400)
            {
                return new BaseResponse<PresentationPositionVarietyDto>
                {
                    Message = result.Message,
                    Response = presentationDto,
                    StatusCode = result.StatusCode,
                };
            }
            return new BaseResponse<PresentationPositionVarietyDto>
            {
                Message = result.Message,
                Response = presentationDto,
                StatusCode = result.StatusCode,
            };
        }

        public BaseResponse<PresentationPositionVarietyDto> DeletePresentationPositionVariety(PresentationPositionVarietyDto presentationDto)
        {
            var isExistedPresentatation = _partographRepo.GetPresentationPositionVarietyById(presentationDto.Id);

            if (isExistedPresentatation.Response is null)
            {
                return new BaseResponse<PresentationPositionVarietyDto>
                {
                    Message = "Not found",
                    Response = presentationDto,
                    StatusCode = StatusCodes.Status400BadRequest,
                };
            }

            Guid userId = _tokenServices.GetUserId();

            isExistedPresentatation.Response.DeleteAt = DateTime.Now;
            isExistedPresentatation.Response.DeletedBy = userId;

            var result = _partographRepo.UpdatePresentationPositionVariety(isExistedPresentatation.Response);

            if (result.StatusCode == 400)
            {
                return new BaseResponse<PresentationPositionVarietyDto>
                {
                    Message = result.Message,
                    Response = presentationDto,
                    StatusCode = result.StatusCode,
                };
            }
            return new BaseResponse<PresentationPositionVarietyDto>
            {
                Message = result.Message,
                Response = presentationDto,
                StatusCode = result.StatusCode,
            };
        }

        public BaseResponse<List<MedicalSurveillanceTableEntity>> GetAllMedicalSurveillanceTable()
        {
            var result = _partographRepo.GetAllMedicalSurveillanceTables();

            return result;
        }

        public BaseResponse<MedicalSurveillanceTableEntity> GetMedicalSurveillanceTableById(int medicalId)
        {
            var result = _partographRepo.GetMedicalSurveillanceTablesById(medicalId);

            return result;
        }

        public BaseResponse<List<MedicalSurveillanceTableEntity>> GetMedicalSurveillanceTableByParthographId(Guid medicalId)
        {
            var result = _partographRepo.GetMedicalSurveillanceTablesByParthographId(medicalId);

            return result;
        }

        public BaseResponse<MedicalSurveillanceTableDTO> CreateMedicalSurveillanceTable(MedicalSurveillanceTableDTO medicalDto)
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

            var result = _partographRepo.CreateMedicalSurveillanceTable(entity);

            if (result.StatusCode == 400)
            {
                return new BaseResponse<MedicalSurveillanceTableDTO>
                {
                    Message = result.Message,
                    Response = medicalDto,
                    StatusCode = result.StatusCode
                };
            }

            return new BaseResponse<MedicalSurveillanceTableDTO>
            {
                Message = result.Message,
                Response = medicalDto,
                StatusCode = result.StatusCode
            };
        }

        public BaseResponse<MedicalSurveillanceTableDTO> UpdateMedicalSurveillanceTable(MedicalSurveillanceTableDTO medicalDto)
        {
            var isExistedMedical = _partographRepo.GetMedicalSurveillanceTablesById(medicalDto.Id);

            if (isExistedMedical.Response is null)
            {
                return new BaseResponse<MedicalSurveillanceTableDTO>
                {
                    Message = "Not found",
                    Response = medicalDto,
                    StatusCode = isExistedMedical.StatusCode
                };
            }

            Guid userId = _tokenServices.GetUserId();

            isExistedMedical.Response.Letter = medicalDto.Letter;
            isExistedMedical.Response.MaternalPosition = medicalDto.MaternalPosition;
            isExistedMedical.Response.ArterialPressure = medicalDto.ArterialPressure;
            isExistedMedical.Response.MaternalPulse = medicalDto.MaternalPulse;
            isExistedMedical.Response.FetalHeartRate = medicalDto.FetalHeartRate;
            isExistedMedical.Response.ContractionsDuration = medicalDto.ContractionsDuration;
            isExistedMedical.Response.FrequencyContractions = medicalDto.FrequencyContractions;
            isExistedMedical.Response.Pain = medicalDto.Pain;
            isExistedMedical.Response.UpdateAt = DateTime.Now;
            isExistedMedical.Response.UpdateBy = userId;

            var result = _partographRepo.UpdateMedicalSurveillanceTable(isExistedMedical.Response);

            if (result.StatusCode == 400)
            {
                return new BaseResponse<MedicalSurveillanceTableDTO>
                {
                    Message = result.Message,
                    Response = medicalDto,
                    StatusCode = result.StatusCode,
                };
            }
            return new BaseResponse<MedicalSurveillanceTableDTO>
            {
                Message = result.Message,
                Response = medicalDto,
                StatusCode = result.StatusCode,
            };
        }

        public BaseResponse<MedicalSurveillanceTableDTO> DeleteMedicalSurveillanceTable(MedicalSurveillanceTableDTO medicalDto)
        {
            var isExistedMedical = _partographRepo.GetMedicalSurveillanceTablesById(medicalDto.Id);

            if (isExistedMedical.Response is null)
            {
                return new BaseResponse<MedicalSurveillanceTableDTO>
                {
                    Message = "Not found",
                    Response = medicalDto,
                    StatusCode = isExistedMedical.StatusCode
                };
            }

            Guid userId = _tokenServices.GetUserId();

            isExistedMedical.Response.IsDelete = true;
            isExistedMedical.Response.DeleteAt = DateTime.Now;
            isExistedMedical.Response.DeletedBy = userId;

            var result = _partographRepo.UpdateMedicalSurveillanceTable(isExistedMedical.Response);

            if (result.StatusCode == 400)
            {
                return new BaseResponse<MedicalSurveillanceTableDTO>
                {
                    Message = result.Message,
                    Response = medicalDto,
                    StatusCode = result.StatusCode,
                };
            }
            return new BaseResponse<MedicalSurveillanceTableDTO>
            {
                Message = result.Message,
                Response = medicalDto,
                StatusCode = result.StatusCode,
            };
        }
    }
}