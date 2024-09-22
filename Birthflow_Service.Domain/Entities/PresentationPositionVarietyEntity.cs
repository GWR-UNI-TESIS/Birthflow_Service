using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BirthflowService.Domain.Entities
{
    [Table("PresentationPositionVariety", Schema = "Partograph")]
    public class PresentationPositionVarietyEntity
    {
        [Key, Column(TypeName = "bigint")]
        public long Id { get; set; }

        [ForeignKey("PartographEntity")]
        public Guid PartographId { get; set; }

        [ForeignKey("HodgePlanesEntity")]
        public int HodgePlane { get; set; }

        [ForeignKey("PositionEntity")]
        public int Position { get; set; }

        public DateTime Time { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public DateTime? DeleteAt { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? UpdateBy { get; set; }
        public Guid? DeletedBy { get; set; }
        public virtual PartographEntity? Partograph { get; set; }
        public virtual HodgePlanesEntity? HodgePlanesEntity { get; set; }  
        public virtual PositionEntity? PositionEntity { get; set; }
    }
}