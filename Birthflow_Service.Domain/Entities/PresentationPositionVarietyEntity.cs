using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birthflow_Domain.Entities
{
    [Table("PresentationPositionVariety", Schema = "Partograph")]
    public class PresentationPositionVarietyEntity
    {
        [Key, Column(TypeName = "bigint")]
        public int Id { get; set; }
        [ForeignKey("PartographEntity")]
        public Guid PartographId { get; set; }
        public string HodgePlane { get; set; } = null!;
        public string Position { get; set; } = null!;
        public DateTime Time { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public DateTime? DeleteAt { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? UpdateBy { get; set; }
        public Guid? DeletedBy { get; set; }
        public virtual PartographEntity? Partograph { get; set; }
    }
}
