using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BirthflowService.Domain.Entities
{
    [Table("PartographGroupShare", Schema = "Partograph")]
    public class PartographGroupShareEntity
    {
        [Key]
        public long Id { get; set; }
        [ForeignKey("PartographGroup")]
        public Guid PartographGroupId { get; set; }
        [ForeignKey("UserEntity")]
        public Guid? UserId { get; set; }
        [ForeignKey("GroupEntity")]
        public long? GroupId { get; set; }
        [ForeignKey("PermissionTypeEntity")]
        public int? PermissionTypeId { get; set; }

        public DateTime CreatedAt { get; set; }

        public UserEntity? UserEntity { get; set; }
        public PartographGroupEntity? PartographGroupEntity { get; set; }
        public GroupEntity? GroupEntity { get; set; }
        public PermissionTypeEntity? AccessPermission { get; set; }
    }
}
