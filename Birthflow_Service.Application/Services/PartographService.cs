using AutoMapper;
using Birthflow_Application.DTOs;
using BirthflowService.Application.Interfaces;
using BirthflowService.Application.Utils;
using BirthflowService.Domain.DTOs.Partograph;
using BirthflowService.Domain.Entities;
using BirthflowService.Domain.Interface;
using BirthflowService.Domain.Models;
using BirthflowService.Domain.Models.Log;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Security.AccessControl;

namespace BirthflowService.Application.Services
{
    public class PartographService : IPartographService
    {
        private readonly IConfiguration _configuration;
        private readonly IPartographRepository _partographRepo;
        private readonly IUserTokenService _tokenServices;
        private readonly IMapper _mapper;
        private readonly IPartographLogService _partographLogService;
        private readonly ICurvesGenerator _curvesGenerator;

        public PartographService(IConfiguration configuration, IPartographRepository partographRepo, IUserTokenService tokenServices, 
            IMapper mapper, IPartographLogService partographLogService, ICurvesGenerator curvesGenerator)
        {
            _configuration = configuration;
            _partographRepo = partographRepo;
            _tokenServices = tokenServices;
            _mapper = mapper;
            _partographLogService = partographLogService;
            _curvesGenerator = curvesGenerator;
        }

        public async Task<BaseResponse<PartographEntity>> CreatePartograph(PartographDto partographDto)
        {
            try
            {
                Guid userId = _tokenServices.GetUserId();

                var partographEntity = _mapper.Map<PartographEntity>(partographDto);

                partographEntity.PartographId = Guid.NewGuid();
                partographEntity.CreatedBy = userId;
                partographEntity.CreatedAt = DateTime.Now;

                var result = await _partographRepo.CreatePartograph(partographEntity);

                var currentEntity = _mapper.Map<PartographLog>(result);
                await _partographLogService.SaveLog(currentEntity, result, userId);

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

        public async Task<BaseResponse<PartographResponseDto>> GetPartograph(Guid partographId)
        {
            try
            {
                var result = await _partographRepo.GetPartograph(partographId);
                
                var response = _mapper.Map<PartographResponseDto>(result);
                return new BaseResponse<PartographResponseDto>
                {
                    Message = "Ingresado correctamente",
                    Response = response,
                    StatusCode = StatusCodes.Status200OK,
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<PartographResponseDto>
                {
                    Response = null!,
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status400BadRequest,
                };
            }
        }

        public async Task<BaseResponse<PartographEntity>> UpdatePartograph(PartographDto partographDto)
        {
            try
            {
                var partographEntity = await _partographRepo.GetPartograph((Guid)partographDto.PartographId!);

                if (partographEntity == null)
                    return new BaseResponse<PartographEntity>
                    {
                        Message = "Not Found",
                        Response = { },
                        StatusCode = StatusCodes.Status200OK,
                    };

                Guid userId = _tokenServices.GetUserId();
                var currentEntity = _mapper.Map<PartographLog>(partographEntity);
                var newEntity = _mapper.Map<PartographLog>(partographDto);

                //Fase de guardar la info nueva
                _mapper.Map(partographDto, partographEntity);

                partographEntity.UpdateAt = DateTime.Now;
                partographEntity.UpdateBy = userId;

                var result = await _partographRepo.UpdatePartograph(partographEntity);

                await _partographLogService.SaveLog(currentEntity, newEntity, result, userId);

                return new BaseResponse<PartographEntity>
                {
                    Message = "Partograma modificado correctamente",
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

        public async Task<BaseResponse<PartographEntity>> DeletePartograph(Guid partographId)
        {
            try
            {
                var partographEntity = await _partographRepo.GetPartograph(partographId);

                if (partographEntity == null)
                    return new BaseResponse<PartographEntity>
                    {
                        Message = "Not Found",
                        Response = { },
                        StatusCode = StatusCodes.Status200OK,
                    };

                Guid userId = _tokenServices.GetUserId();

                partographEntity.IsDelete = true;
                partographEntity.DeletedAt = DateTime.Now;
                partographEntity.DeletedBy = userId;

                var result = await _partographRepo.UpdatePartograph(partographEntity);

                return new BaseResponse<PartographEntity>
                {
                    Message = "Partograma eliminado correctamente",
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
                Guid userId = _tokenServices.GetUserId();

                var cervicalDilationEntity = _mapper.Map<CervicalDilationEntity>(cervicalDilationDto);

                cervicalDilationEntity.CreatedBy = userId;
                cervicalDilationEntity.CreateAt = DateTime.Now;

                var result = await _partographRepo.CreateCervicalDilation(cervicalDilationEntity);

                var currentEntity = _mapper.Map<CervicalDilationLog>(result);

                var partographEntity = await _partographRepo.GetPartograph(result.PartographId);

                partographEntity.CervicalDilationEntities = partographEntity.CervicalDilationEntities
                    .OrderBy(cd => cd.CreateAt) // Usa el campo adecuado que indique el orden cronológico
                    .ToList();

                await _partographLogService.SaveLog(currentEntity, partographEntity, userId);

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
                if (cervicalDilationDto.Id == null)
                    return new BaseResponse<CervicalDilationEntity>
                    {
                        Response = null!,
                        Message = "ID no encontrado",
                        StatusCode = StatusCodes.Status400BadRequest,
                    };

                var cervicalDilation = await _partographRepo.GetCervicalDilation((long)cervicalDilationDto.Id!);
                if (cervicalDilation == null)
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
                    Guid userId = _tokenServices.GetUserId();
                    var currentEntity = _mapper.Map<CervicalDilationLog>(cervicalDilation);
                    var newEntity = _mapper.Map<CervicalDilationLog>(cervicalDilationDto);

                    _mapper.Map(cervicalDilationDto, cervicalDilation);

                    cervicalDilation.UpdateBy = userId;
                    cervicalDilation.UpdateAt = DateTime.Now;

                    var result = await _partographRepo.UpdateCervicalDilation(cervicalDilation);

                    var partographEntity = await _partographRepo.GetPartograph(result.PartographId);
                    await _partographLogService.SaveLog(currentEntity, newEntity, partographEntity, userId);

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

        public async Task<BaseResponse<PresentationPositionVarietyEntity>> CreatePresentationPositionVariety(PresentationPositionVarietyDto presentationDto)
        {
            try
            {
                Guid userId = _tokenServices.GetUserId();

                var entity = _mapper.Map<PresentationPositionVarietyEntity>(presentationDto);

                entity.CreateAt = DateTime.Now;
                entity.CreatedBy = userId;
                entity.IsDelete = false;

                var result = await _partographRepo.CreatePresentationPositionVariety(entity);

                var currentEntity = _mapper.Map<PresentationPositionVarietyLog>(result);
                var partographEntity = await _partographRepo.GetPartograph(result.PartographId);
                await _partographLogService.SaveLog(currentEntity, partographEntity, userId);

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

                var currentEntity = _mapper.Map<MedicalSurveillanceTableLog>(isExistedPresentatation);
                var newEntity = _mapper.Map<MedicalSurveillanceTableLog>(presentationDto);

                Guid userId = _tokenServices.GetUserId();

                _mapper.Map(presentationDto, isExistedPresentatation);
                isExistedPresentatation.UpdateAt = DateTime.Now;
                isExistedPresentatation.UpdateBy = userId;

                var result = await _partographRepo.UpdatePresentationPositionVariety(isExistedPresentatation);

                var partographEntity = await _partographRepo.GetPartograph(result.PartographId);
                await _partographLogService.SaveLog(currentEntity, newEntity, partographEntity, userId);
       
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

                isExistedPresentatation.IsDelete = true;
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

        public async Task<BaseResponse<MedicalSurveillanceTableEntity>> CreateMedicalSurveillanceTable(MedicalSurveillanceTableDto medicalDto)
        {
            try
            {
                Guid userId = _tokenServices.GetUserId();
                var entity = _mapper.Map<MedicalSurveillanceTableEntity>(medicalDto);

                entity.CreateAt = DateTime.Now;
                entity.CreatedBy = userId;

                var result = await _partographRepo.CreateMedicalSurveillanceTable(entity);

                var currentEntity = _mapper.Map<MedicalSurveillanceTableLog>(result);
                var partographEntity = await _partographRepo.GetPartograph(result.PartographId);
                await _partographLogService.SaveLog(currentEntity, partographEntity, userId);

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

        public async Task<BaseResponse<MedicalSurveillanceTableEntity>> UpdateMedicalSurveillanceTable(MedicalSurveillanceTableDto medicalDto)
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
                var currentEntity = _mapper.Map<MedicalSurveillanceTableLog>(isExistedMedical);
                var newEntity = _mapper.Map<MedicalSurveillanceTableLog>(medicalDto);

                _mapper.Map(medicalDto, isExistedMedical);

                isExistedMedical.UpdateAt = DateTime.Now;
                isExistedMedical.UpdateBy = userId;

                var result = await _partographRepo.UpdateMedicalSurveillanceTable(isExistedMedical);

                var partographEntity = await _partographRepo.GetPartograph(result.PartographId);
                await _partographLogService.SaveLog(currentEntity, newEntity, partographEntity, userId);

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

        public async Task<BaseResponse<MedicalSurveillanceTableEntity>> DeleteMedicalSurveillanceTable(MedicalSurveillanceTableDto medicalDto)
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

                _mapper.Map(partographStateDto, response);

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

        public async Task<BaseResponse<FetalHeartRateEntity>> GetFetalHeartRate(long id)
        {
            try
            {
                var result = await _partographRepo.GetFetalHeartRate(id);
                if (result == null)
                {
                    return new BaseResponse<FetalHeartRateEntity>
                    {
                        Message = "Frecuencia cardíaca fetal no encontrada",
                        Response = null!,
                        StatusCode = StatusCodes.Status404NotFound,
                    };
                }

                return new BaseResponse<FetalHeartRateEntity>
                {
                    Message = "Frecuencia cardíaca fetal recuperada correctamente",
                    Response = result,
                    StatusCode = StatusCodes.Status200OK,
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<FetalHeartRateEntity>
                {
                    Response = null!,
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status400BadRequest,
                };
            }
        }

        public async Task<BaseResponse<IEnumerable<FetalHeartRateEntity>>> GetFetalHeartRateByParthographId(Guid partographId)
        {
            try
            {
                var result = await _partographRepo.GetFetalHeartRateByParthographId(partographId);
                return new BaseResponse<IEnumerable<FetalHeartRateEntity>>
                {
                    Message = "Frecuencia cardíaca fetal recuperada correctamente",
                    Response = result,
                    StatusCode = StatusCodes.Status200OK,
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<FetalHeartRateEntity>>
                {
                    Response = null!,
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status400BadRequest,
                };
            }
        }

        public async Task<BaseResponse<FetalHeartRateEntity>> CreateFetalHeartRate(FetalHeartRateDto fetalHeartRateDto)
        {
            try
            {
                Guid userId = _tokenServices.GetUserId();
                var fetalHeartRateEntity = _mapper.Map<FetalHeartRateEntity>(fetalHeartRateDto);
                fetalHeartRateEntity.CreatedBy = userId;
                fetalHeartRateEntity.CreateAt = DateTime.Now;

                var result = await _partographRepo.CreateFetalHeartRate(fetalHeartRateEntity);

                var currentEntity = _mapper.Map<FetalHeartRateLog>(result);
                var partographEntity = await _partographRepo.GetPartograph(result.PartographId);
                await _partographLogService.SaveLog(currentEntity, partographEntity, userId);
 
                return new BaseResponse<FetalHeartRateEntity>
                {
                    Message = "Frecuencia cardíaca fetal creada correctamente",
                    Response = result,
                    StatusCode = StatusCodes.Status200OK,
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<FetalHeartRateEntity>
                {
                    Response = null!,
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status400BadRequest,
                };
            }
        }

        public async Task<BaseResponse<FetalHeartRateEntity>> UpdateFetalHeartRateTable(FetalHeartRateDto fetalHeartRateDto)
        {
            try
            {
                var isExistedFetalHeartRate = await _partographRepo.GetFetalHeartRate((long)fetalHeartRateDto.Id!);

                if (isExistedFetalHeartRate == null)
                {
                    return new BaseResponse<FetalHeartRateEntity>
                    {
                        Message = "No encontrado",
                        Response = null!,
                        StatusCode = StatusCodes.Status404NotFound,
                    };
                }

                Guid userId = _tokenServices.GetUserId();
                var currentEntity = _mapper.Map<FetalHeartRateLog>(isExistedFetalHeartRate);
                var newEntity = _mapper.Map<FetalHeartRateLog>(fetalHeartRateDto);


                _mapper.Map(fetalHeartRateDto, isExistedFetalHeartRate);
                isExistedFetalHeartRate.UpdateBy = userId;
                isExistedFetalHeartRate.UpdateAt = DateTime.Now;

                var result = await _partographRepo.UpdateFetalHeartRateTable(isExistedFetalHeartRate);

                var partographEntity = await _partographRepo.GetPartograph(result.PartographId);
                await _partographLogService.SaveLog(currentEntity, newEntity, partographEntity, userId);

                return new BaseResponse<FetalHeartRateEntity>
                {
                    Message = "Frecuencia cardíaca fetal actualizada correctamente",
                    Response = result,
                    StatusCode = StatusCodes.Status200OK,
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<FetalHeartRateEntity>
                {
                    Response = null!,
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status400BadRequest,
                };
            }
        }

        public async Task<BaseResponse<ContractionFrequencyEntity>> GetContractionFrequency(long id)
        {
            try
            {
                var result = await _partographRepo.GetContractionFrequency(id);
                return new BaseResponse<ContractionFrequencyEntity>
                {
                    Message = "Frecuencia de contracción obtenida correctamente",
                    Response = result,
                    StatusCode = StatusCodes.Status200OK,
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<ContractionFrequencyEntity>
                {
                    Response = null!,
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status400BadRequest,
                };
            }
        }

        public async Task<BaseResponse<IEnumerable<ContractionFrequencyEntity>>> GetContractionFrequencyByParthographId(Guid partographId)
        {
            try
            {
                var result = await _partographRepo.GetContractionFrequencyByParthographId(partographId);
                return new BaseResponse<IEnumerable<ContractionFrequencyEntity>>
                {
                    Message = "Frecuencia de contracciones obtenida correctamente",
                    Response = result,
                    StatusCode = StatusCodes.Status200OK,
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<ContractionFrequencyEntity>>
                {
                    Response = null!,
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status400BadRequest,
                };
            }
        }

        public async Task<BaseResponse<ContractionFrequencyEntity>> CreateContractionFrequency(ContractionFrequencyDto contractionFrequencyDto)
        {
            try
            {
                Guid userId = _tokenServices.GetUserId();

                var contractionFrequencyEntity = _mapper.Map<ContractionFrequencyEntity>(contractionFrequencyDto);
                contractionFrequencyEntity.CreatedBy = userId;
                contractionFrequencyEntity.CreateAt = DateTime.Now;

                var result = await _partographRepo.CreateContractionFrequency(contractionFrequencyEntity);

                var currentEntity = _mapper.Map<ContractionFrequencyLog>(result);
                var partographEntity = await _partographRepo.GetPartograph(result.PartographId);
                await _partographLogService.SaveLog(currentEntity, partographEntity, userId);

                return new BaseResponse<ContractionFrequencyEntity>
                {
                    Message = "Frecuencia de contracciones creada correctamente",
                    Response = result,
                    StatusCode = StatusCodes.Status200OK,
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<ContractionFrequencyEntity>
                {
                    Response = null!,
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status400BadRequest,
                };
            }
        }

        public async Task<BaseResponse<ContractionFrequencyEntity>> UpdateContractionFrequency(ContractionFrequencyDto contractionFrequencyDto)
        {
            try
            {
                var isExistedContractionFrequency = await _partographRepo.GetContractionFrequency((long)contractionFrequencyDto.Id!);

                if (isExistedContractionFrequency == null)
                {
                    return new BaseResponse<ContractionFrequencyEntity>
                    {
                        Message = "No encontrado",
                        Response = null!,
                        StatusCode = StatusCodes.Status404NotFound,
                    };
                }

                Guid userId = _tokenServices.GetUserId();
                var currentEntity = _mapper.Map<ContractionFrequencyLog>(isExistedContractionFrequency);
                var newEntity = _mapper.Map<ContractionFrequencyLog>(contractionFrequencyDto);

                _mapper.Map(contractionFrequencyDto, isExistedContractionFrequency);
                isExistedContractionFrequency.UpdateBy = userId;
                isExistedContractionFrequency.UpdateAt = DateTime.Now;

                var result = await _partographRepo.UpdateContractionFrequency(isExistedContractionFrequency);

                var partographEntity = await _partographRepo.GetPartograph(result.PartographId);
                await _partographLogService.SaveLog(currentEntity, newEntity, partographEntity, userId);

                return new BaseResponse<ContractionFrequencyEntity>
                {
                    Message = "Frecuencia de contracciones actualizada correctamente",
                    Response = result,
                    StatusCode = StatusCodes.Status200OK,
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<ContractionFrequencyEntity>
                {
                    Response = null!,
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status400BadRequest,
                };
            }
        }

        public async Task<BaseResponse<ChildbirthNoteEntity>> GetChildBirthNoteByParthographId(Guid partographId)
        {
            try
            {
                var result = await _partographRepo.GetChildBirthNoteByParthographId(partographId);
                return new BaseResponse<ChildbirthNoteEntity>
                {
                    Message = "Nota de parto obtenida correctamente",
                    Response = result,
                    StatusCode = StatusCodes.Status200OK,
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<ChildbirthNoteEntity>
                {
                    Response = null!,
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status400BadRequest,
                };
            }
        }

        public async Task<BaseResponse<ChildbirthNoteEntity>> CreateChildBirthNote(ChildbirthNoteDto childbirthNoteDto)
        {
            try
            {
                Guid userId = _tokenServices.GetUserId();

                var childbirthNote = _mapper.Map<ChildbirthNoteEntity>(childbirthNoteDto);
                childbirthNote.CreatedBy = userId;
                childbirthNote.CreateAt = DateTime.Now;

                var result = await _partographRepo.CreateChildBirthNote(childbirthNote);

                var currentEntity = _mapper.Map<ChildbirthNoteLog>(result);
                var partographEntity = await _partographRepo.GetPartograph(result.PartographId);
                await _partographLogService.SaveLog(currentEntity, partographEntity, userId);

                return new BaseResponse<ChildbirthNoteEntity>
                {
                    Message = "Nota de parto creada correctamente",
                    Response = result,
                    StatusCode = StatusCodes.Status200OK,
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<ChildbirthNoteEntity>
                {
                    Response = null!,
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status400BadRequest,
                };
            }
        }

        public async Task<BaseResponse<ChildbirthNoteEntity>> UpdateChildBirthNote(ChildbirthNoteDto childbirthNoteDto)
        {
            try
            {
                var isExistedChildbirthNote = await _partographRepo.GetChildBirthNoteByParthographId((Guid)childbirthNoteDto.PartographId!);

                if (isExistedChildbirthNote == null)
                {
                    return new BaseResponse<ChildbirthNoteEntity>
                    {
                        Message = "No encontrado",
                        Response = null!,
                        StatusCode = StatusCodes.Status404NotFound,
                    };
                }

                Guid userId = _tokenServices.GetUserId();
                var currentEntity = _mapper.Map<ChildbirthNoteLog>(isExistedChildbirthNote);
                var newEntity = _mapper.Map<ChildbirthNoteLog>(childbirthNoteDto);

                _mapper.Map(childbirthNoteDto, isExistedChildbirthNote);
                isExistedChildbirthNote.UpdateBy = userId;
                isExistedChildbirthNote.UpdateAt = DateTime.Now;

                var result = await _partographRepo.UpdateChildBirthNote(isExistedChildbirthNote);

                var partographEntity = await _partographRepo.GetPartograph(result.PartographId);
                await _partographLogService.SaveLog(currentEntity, newEntity, partographEntity, userId);

                return new BaseResponse<ChildbirthNoteEntity>
                {
                    Message = "Nota de parto actualizada correctamente",
                    Response = result,
                    StatusCode = StatusCodes.Status200OK,
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<ChildbirthNoteEntity>
                {
                    Response = null!,
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status400BadRequest,
                };
            }
        }

        public async Task<BaseResponse<PartographStateEntity>> GetPartographStateByUser(Guid partographId, Guid userId)
        {
            try
            {
                var result = await _partographRepo.GetPartographStateByUser(partographId, userId);

                if (result == null)
                {
                    return new BaseResponse<PartographStateEntity>
                    {
                        Response = null!,
                        Message = "Estado del partograma no encontrado",
                        StatusCode = StatusCodes.Status404NotFound,
                    };
                }

                return new BaseResponse<PartographStateEntity>
                {
                    Message = "Estado del partograma obtenido correctamente",
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

        public async Task<BaseResponse<Curves>> GetAlertCurves(Guid partographId)
        {
            try
            {
                var result = await _partographRepo.GetPartograph(partographId);

                var curves = _curvesGenerator.GenerateCurves(result);

                return new BaseResponse<Curves>
                {
                    Message = "Ingresado correctamente",
                    Response = curves,
                    StatusCode = StatusCodes.Status200OK,
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<Curves>
                {
                    Response = null!,
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status400BadRequest,

                };
            }
        }
    }
}