using System.ComponentModel.DataAnnotations.Schema;

namespace BirthflowService.Domain.Entities
{
    [Table("PartographAuditLog", Schema = "Partograph")]
    public class PartographAuditLogEntity
    {
        public int Id { get; set; }
        public Guid PartographId { get; set; }
        public required string EntityName { get; set; } // Nombre de la entidad (ej. "MedicalSurveillanceTableEntity")
        public required string FieldName { get; set; }  // Campo que fue modificado
        public required string OldValue { get; set; }   // Valor anterior
        public required string NewValue { get; set; }   // Nuevo valor
        public DateTime ChangedAt { get; set; }
        public Guid ChangedBy { get; set; }

        // Relación opcional con la versión de partograma relacionada con estos cambios
        [ForeignKey("PartographVersionEntity")]
        public int? PartographVersionId { get; set; }
        public PartographVersionEntity? PartographVersion { get; set; }
    }
}
