using BirthflowMicroServices.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthflowService.Domain.Entities
{
    [Table("Partographs", Schema = "Partograph")]
    public class PartographEntity
    {
        [Key]
        public Guid PartographId { get; set; }
        public required string Name { get; set; }
        public required string RecordName { get; set; }
        public required DateTime Date { get; set; }
        public required string Observation { get; set; }
        [MaxLength(3), ForeignKey("WorkTimeEntity")]
        public required string WorkTime { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreatedAt { get; set; }
        [ForeignKey("UsuarioEntity")]
        public Guid? CreatedBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public Guid? UpdateBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public Guid? DeletedBy { get; set; }
        public UsuarioEntity? UsuarioEntity { get; set; }
        public virtual WorkTimeEntity? WorkTimeEntity { get; set; }
        public virtual ChildbirthNoteEntity? BirthNote { get; set; }
        public virtual ICollection<CervicalDilationEntity> CervicalDilationEntities { get; set; } = new List<CervicalDilationEntity>();
        public virtual ICollection<ContractionFrequencyEntity> ContractionFrequencyEntities { get; set; } = new List<ContractionFrequencyEntity>();
        public virtual ICollection<FetalHeartRateEntity> FetalHeartRateEntities { get; set; } = new List<FetalHeartRateEntity>();
        public virtual ICollection<MedicalSurveillanceTableEntity> MedicalSurveillanceTableEntities { get; set; } = new List<MedicalSurveillanceTableEntity>();
        public virtual ICollection<PresentationPositionVarietyEntity> PresentationPositionVarietyEntities { get; set; } = new List<PresentationPositionVarietyEntity>();
    }
}
