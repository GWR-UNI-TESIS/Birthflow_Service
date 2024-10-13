using AutoMapper;
using Birthflow_Application.DTOs;
using BirthflowService.Application.Interfaces;
using BirthflowService.Domain.DTOs.Share;
using BirthflowService.Domain.Entities;
using BirthflowService.Domain.Interface;
using Microsoft.AspNetCore.Http;

namespace BirthflowService.Application.Services
{
    public class ShareService : IShareService
    {

        private readonly IShareRepository _shareRepository;
        private readonly IUserTokenService _tokenServices;
        private readonly IMapper _mapper;

        public ShareService(IShareRepository shareRepository, IUserTokenService tokenServices)
        {
            _shareRepository = shareRepository;
            _tokenServices = tokenServices;
        }

        public async Task<BaseResponse<IEnumerable<GroupEntity>>> GetGroupsByUserId(Guid userId)
        {
            try
            {
                var result = await _shareRepository.GetGroupsByUserId(userId);

                return new BaseResponse<IEnumerable<GroupEntity>>
                {
                    Message = "",
                    Response = result,
                    StatusCode = StatusCodes.Status200OK,
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<GroupEntity>>
                {
                    Response = null!,
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status400BadRequest,
                };
            }
        }
        public async Task<BaseResponse<GroupEntity>> CreateGroup(GroupDto dto)
        {
            try
            {
                Guid userId = _tokenServices.GetUserId();

                var groupEntity = _mapper.Map<GroupEntity>(dto);

                groupEntity.CreatedAt = DateTime.UtcNow;
                groupEntity.CreatedBy = userId;

                var result = await _shareRepository.CreateGroup(groupEntity);

                return new BaseResponse<GroupEntity>
                {
                    Message = "",
                    Response = result,
                    StatusCode = StatusCodes.Status200OK,
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<GroupEntity>
                {
                    Response = null!,
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status400BadRequest,
                };
            }
        }
        public async Task<BaseResponse<GroupEntity>> UpdateGroup(GroupDto dto)
        {
            try
            {
                var entity = await _shareRepository.GetGroupById((long)dto.Id!);

                if (entity == null)
                    return new BaseResponse<GroupEntity>
                    {
                        Message = "Not Found",
                        Response = { },
                        StatusCode = StatusCodes.Status200OK,
                    };

                Guid userId = _tokenServices.GetUserId();

                _mapper.Map(dto, entity);

                var result = await _shareRepository.UpdateGroup(entity);

                return new BaseResponse<GroupEntity>
                {
                    Message = "",
                    Response = result,
                    StatusCode = StatusCodes.Status200OK,
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<GroupEntity>
                {
                    Response = null!,
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status400BadRequest,
                };
            }
        }
        public async Task<BaseResponse<GroupEntity>> DeleteGroup(GroupDto dto)
        {
            try
            {
                var entity = await _shareRepository.GetGroupById((long)dto.Id!);

                if (entity == null)
                    return new BaseResponse<GroupEntity>
                    {
                        Message = "Not Found",
                        Response = { },
                        StatusCode = StatusCodes.Status200OK,
                    };

                Guid userId = _tokenServices.GetUserId();

                _mapper.Map(dto, entity);

                var result = await _shareRepository.DeleteGroup(entity);

                return new BaseResponse<GroupEntity>
                {
                    Message = "",
                    Response = result,
                    StatusCode = StatusCodes.Status200OK,
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<GroupEntity>
                {
                    Response = null!,
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status400BadRequest,
                };
            }
        }

        //Obtiene los partogramas
        public async Task<BaseResponse<IEnumerable<PartographGroupItemEntity>>> GetPartographGroupItemForUser(Guid userId, long groupId)
        {
            try
            {
                var result = await _shareRepository.GetPartographGroupItemForUser(userId, groupId);

                return new BaseResponse<IEnumerable<PartographGroupItemEntity>>
                {
                    Message = "",
                    Response = result,
                    StatusCode = StatusCodes.Status200OK,
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<PartographGroupItemEntity>>
                {
                    Response = null!,
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status400BadRequest,
                };
            }
        }
        public async Task<BaseResponse<PartographGroupItemEntity>> CreatePartographGroupItem(PartographGroupItemDto dto)
        {
            try
            {
                var groupEntity = _mapper.Map<PartographGroupItemEntity>(dto);

                groupEntity.CreatedAt = DateTime.UtcNow;

                var result = await _shareRepository.CreatePartographGroupItem(groupEntity);

                return new BaseResponse<PartographGroupItemEntity>
                {
                    Message = "",
                    Response = result,
                    StatusCode = StatusCodes.Status200OK,
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<PartographGroupItemEntity>
                {
                    Response = null!,
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status400BadRequest,
                };
            }
        }
        public async Task<BaseResponse<PartographGroupItemEntity>> DeletePartographGroupItem(PartographGroupItemDto dto)
        {
            try
            {
                var entity = await _shareRepository.FindPartographGroupItem(dto.PartographId, dto.PartographGroupId );

                if (entity == null)
                    return new BaseResponse<PartographGroupItemEntity>
                    {
                        Message = "Not Found",
                        Response = { },
                        StatusCode = StatusCodes.Status200OK,
                    };

                var result = await _shareRepository.DeletePartographGroupItem(entity);

                return new BaseResponse<PartographGroupItemEntity>
                {
                    Message = "",
                    Response = result,
                    StatusCode = StatusCodes.Status200OK,
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<PartographGroupItemEntity>
                {
                    Response = null!,
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status400BadRequest,
                };
            }
        }

        //Compartir partograma individual
        public async Task<BaseResponse<PartographShareEntity>> CreatePartographShare(PartographShareDto dto)
        {
            try
            {
                var groupEntity = _mapper.Map<PartographShareEntity>(dto);

                groupEntity.CreatedAt = DateTime.UtcNow;

                var result = await _shareRepository.CreatePartographShare(groupEntity);

                return new BaseResponse<PartographShareEntity>
                {
                    Message = "",
                    Response = result,
                    StatusCode = StatusCodes.Status200OK,
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<PartographShareEntity>
                {
                    Response = null!,
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status400BadRequest,
                };
            }
        }
        public async Task<BaseResponse<PartographShareEntity>> UpdatePartographShare(PartographShareDto dto)
        {
            try
            {
                var entity = await _shareRepository.FindPartographShare((long)dto.Id!);


                if (entity == null)
                    return new BaseResponse<PartographShareEntity>
                    {
                        Message = "Not Found",
                        Response = { },
                        StatusCode = StatusCodes.Status200OK,
                    };


                _mapper.Map(dto, entity);

                var result = await _shareRepository.UpdatePartographShare(entity);

                return new BaseResponse<PartographShareEntity>
                {
                    Message = "",
                    Response = result,
                    StatusCode = StatusCodes.Status200OK,
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<PartographShareEntity>
                {
                    Response = null!,
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status400BadRequest,
                };
            }
        }
        public async Task<BaseResponse<PartographShareEntity>> DeletePartographShare(PartographShareDto dto)
        {
            try
            {
                var entity = await _shareRepository.FindPartographShare((long)dto.Id!);


                if (entity == null)
                    return new BaseResponse<PartographShareEntity>
                    {
                        Message = "Not Found",
                        Response = { },
                        StatusCode = StatusCodes.Status200OK,
                    };

                var result = await _shareRepository.DeletePartographShare(entity);

                return new BaseResponse<PartographShareEntity>
                {
                    Message = "",
                    Response = result,
                    StatusCode = StatusCodes.Status200OK,
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<PartographShareEntity>
                {
                    Response = null!,
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status400BadRequest,
                };
            }
        }
       

        //Compartir grupo partograma
        public async Task<BaseResponse<PartographGroupShareEntity>> CreatePartographGroupShare(PartographGroupShareDto dto){
            try
            {
                var groupEntity = _mapper.Map<PartographGroupShareEntity>(dto);

                groupEntity.CreatedAt = DateTime.UtcNow;

                var result = await _shareRepository.CreatePartographGroupShare(groupEntity);

                return new BaseResponse<PartographGroupShareEntity>
                {
                    Message = "",
                    Response = result,
                    StatusCode = StatusCodes.Status200OK,
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<PartographGroupShareEntity>
                {
                    Response = null!,
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status400BadRequest,
                };
            }
        }
        public async Task<BaseResponse<PartographGroupShareEntity>> UpdatePartographGroupShare(PartographGroupShareDto dto)
        {
            try
            {
                var entity = await _shareRepository.FindPartographGroupShare((long)dto.Id!);


                if (entity == null)
                    return new BaseResponse<PartographGroupShareEntity>
                    {
                        Message = "Not Found",
                        Response = { },
                        StatusCode = StatusCodes.Status200OK,
                    };

                _mapper.Map(dto, entity);

                var result = await _shareRepository.UpdatePartographGroupShare(entity);

                return new BaseResponse<PartographGroupShareEntity>
                {
                    Message = "",
                    Response = result,
                    StatusCode = StatusCodes.Status200OK,
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<PartographGroupShareEntity>
                {
                    Response = null!,
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status400BadRequest,
                };
            }
        }
        public async Task<BaseResponse<PartographGroupShareEntity>> DeletePartographGroupShare(PartographGroupShareDto dto)
        {
            try
            {
                var entity = await _shareRepository.FindPartographGroupShare((long)dto.Id!);

                if (entity == null)
                    return new BaseResponse<PartographGroupShareEntity>
                    {
                        Message = "Not Found",
                        Response = { },
                        StatusCode = StatusCodes.Status200OK,
                    };

                _mapper.Map(dto, entity);

                var result = await _shareRepository.DeletePartographGroupShare(entity);

                return new BaseResponse<PartographGroupShareEntity>
                {
                    Message = "",
                    Response = result,
                    StatusCode = StatusCodes.Status200OK,
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<PartographGroupShareEntity>
                {
                    Response = null!,
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status400BadRequest,
                };
            }
        }
    }
}
