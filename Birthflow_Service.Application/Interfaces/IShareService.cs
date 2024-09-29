using Birthflow_Application.DTOs;
using BirthflowService.Domain.DTOs.Share;
using BirthflowService.Domain.Entities;

namespace BirthflowService.Application.Interfaces
{
    public interface IShareService
    {
        Task<BaseResponse<IEnumerable<GroupEntity>>> GetGroupsByUserId(Guid userId);
        Task<BaseResponse<GroupEntity>> CreateGroup(GroupDto dto);
        Task<BaseResponse<GroupEntity>> UpdateGroup(GroupDto dto);
        Task<BaseResponse<GroupEntity>> DeleteGroup(GroupDto dto);

        //Obtiene los partogramas
        Task<BaseResponse<IEnumerable<PartographGroupItemEntity>>> GetPartographGroupItemForUser(Guid userId, long groupId);
        Task<BaseResponse<PartographGroupItemEntity>> CreatePartographGroupItem(PartographGroupItemDto dto);
        Task<BaseResponse<PartographGroupItemEntity>> DeletePartographGroupItem(PartographGroupItemDto dto);

        //Compartir partograma individual
        Task<BaseResponse<PartographShareEntity>> CreatePartographShare(PartographShareDto dto);
        Task<BaseResponse<PartographShareEntity>> UpdatePartographShare(PartographShareDto dto);
        Task<BaseResponse<PartographShareEntity>> DeletePartographShare(PartographShareDto dto);

        //Compartir grupo partograma

        Task<BaseResponse<PartographGroupShareEntity>> CreatePartographGroupShare(PartographGroupShareDto dto);
        Task<BaseResponse<PartographGroupShareEntity>> UpdatePartographGroupShare(PartographGroupShareDto dto);
        Task<BaseResponse<PartographGroupShareEntity>> DeletePartographGroupShare(PartographGroupShareDto dto);


        
    }
}
