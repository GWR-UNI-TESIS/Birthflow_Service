using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BirthflowService.Domain.Entities
{
    [Table("Group", Schema = "Partograph")]
    public class GroupEntity
    {
        [Key]
        public long Id { get; set; }
        public required string GroupName { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual ICollection<UserGroupEntity> UserGroups { get; set; } = new List<UserGroupEntity>();

        // Relación uno a muchos con PartographShare
        public virtual ICollection<PartographShareEntity> PartographShares { get; set; } = new List<PartographShareEntity>();

        // Relación uno a muchos con PartographGroupShare
        public virtual ICollection<PartographGroupShareEntity> PartographGroupShares { get; set; } = new List<PartographGroupShareEntity>();

    }
}
