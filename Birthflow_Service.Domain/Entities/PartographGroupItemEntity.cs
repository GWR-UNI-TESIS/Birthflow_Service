using System.ComponentModel.DataAnnotations.Schema;

namespace BirthflowService.Domain.Entities
{
    [Table("PartographGroupItem", Schema = "Partograph")]
    public class PartographGroupItemEntity
    {
        [ForeignKey("PartographEntity")]
        public Guid PartographId { get; set; }
        [ForeignKey("PartographGroupEntity")]
        public long PartographGroupId { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual PartographEntity? Partograph { get; set; }
        public virtual PartographGroupEntity? PartographGroup { get; set; }
    }
}
