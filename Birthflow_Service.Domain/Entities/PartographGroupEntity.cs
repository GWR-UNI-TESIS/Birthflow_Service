using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BirthflowService.Domain.Entities
{
    [Table("PartographGroup", Schema = "Partograph")]
    public class PartographGroupEntity
    {
        [Key]
        public long Id { get; set; }
        public required string Name { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }

        // Relación con los partogramas que pertenecen al grupo
        public ICollection<PartographGroupItemEntity> PartographGroupItems { get; set; } = new List<PartographGroupItemEntity>();

        // Relación con las entidades de compartir (usuarios o grupos)
        public ICollection<PartographGroupShareEntity> PartographGroupShares { get; set; } = new List<PartographGroupShareEntity>();
    }
}
