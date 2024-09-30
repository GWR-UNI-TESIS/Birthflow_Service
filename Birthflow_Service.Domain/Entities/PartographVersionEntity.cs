using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BirthflowService.Domain.Entities
{
    [Table("PartographVersion", Schema = "Partograph")]
    public class PartographVersionEntity
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("PartographEntity")]
        public Guid PartographId { get; set; }
        public DateTime ChangedAt { get; set; }
        public Guid ChangedBy { get; set; }
        [Column(TypeName = "NVARCHAR(MAX)")]
        public required string PartographDataJson { get; set; } // Aquí se almacena el JSON con el estado completo del partograma


        public virtual PartographEntity? PartographEntity { get; set; }

        // Relación opcional con los logs de auditoría asociados a esta versión
        public virtual ICollection<PartographAuditLogEntity> AuditLogs { get; set; } = new List<PartographAuditLogEntity>();
    }
}
