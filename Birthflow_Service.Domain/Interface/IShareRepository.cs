using Birthflow_Application.DTOs;
using BirthflowService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthflowService.Domain.Interface
{
    public interface IShareRepository
    {
        
        Task<IEnumerable<GroupEntity>> GetGroupsByUserId(Guid userId);
        Task<GroupEntity> GetGroupById(long groupId);
        Task<GroupEntity> CreateGroup(GroupEntity entity);
        Task<GroupEntity> UpdateGroup(GroupEntity entity);
        Task<GroupEntity> DeleteGroup(GroupEntity entity);

        //Obtiene los partogramas
        Task<IEnumerable<PartographGroupItemEntity>> GetPartographGroupItemForUser(Guid userId, long groupId);
        Task<PartographGroupItemEntity> FindPartographGroupItem(Guid Partograph, long PartographGroupId);
        Task<PartographGroupItemEntity> CreatePartographGroupItem(PartographGroupItemEntity partographGroupItemEntity);
        Task<PartographGroupItemEntity> UpdatePartographGroupItem(PartographGroupItemEntity partographGroupItemEntity);
        Task<PartographGroupItemEntity> DeletePartographGroupItem(PartographGroupItemEntity partographGroupItemEntity);

        //Compartir partograma individual

        Task<PartographShareEntity> FindPartographShare(long Id);
        Task<PartographShareEntity> CreatePartographShare(PartographShareEntity entity);
        Task<PartographShareEntity> UpdatePartographShare(PartographShareEntity entity);
        Task<PartographShareEntity> DeletePartographShare(PartographShareEntity entity);

        //Compartir grupo partograma

        Task<PartographGroupShareEntity> FindPartographGroupShare(long Id);
        Task<PartographGroupShareEntity> CreatePartographGroupShare(PartographGroupShareEntity entity);
        Task<PartographGroupShareEntity> UpdatePartographGroupShare(PartographGroupShareEntity entity);
        Task<PartographGroupShareEntity> DeletePartographGroupShare(PartographGroupShareEntity entity);
        

        Task<PermissionTypeEntity> GetUserAccessForPartograph(Guid userId, Guid partograph);
        Task<PermissionTypeEntity> GetUserAccessForGroup(Guid userId, long groupId);


    }
}
