using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BirthflowService.Domain.Entities
{
    [Table("PartographShare", Schema = "Partograph")]
    public class PartographShareEntity
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("PartographEntity")]
        public Guid PartographId { get; set; }
        [ForeignKey("UserEntity")]
        public Guid? UserId { get; set; }
        [ForeignKey("GroupEntity")]
        public long? GroupId { get; set; }
        [ForeignKey("PermissionTypeEntity")]
        public int? PermissionTypeId { get; set; }
        public DateTime CreatedAt { get; set; }
        public PartographEntity? PartographEntity { get; set; }
        public UserEntity? User { get; set; }
        public GroupEntity? GroupEntity { get; set; }
        public PermissionTypeEntity? PermissionTypeEntity { get; set; }
    }
}
