using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birthflow_Domain.Entities
{

    [Table("ChildbirthNote", Schema = "Partograph")]
    public class ChildbirthNoteEntity
    {
        [Key]
        public Guid PartographId { get; set; }
        public string? Description { get; set; }
        public string Hour { get; set; } = null!;
        public string Sex { get; set; } = null!;
        public string Apgar { get; set; } = null!;
        public string Temperature { get; set; } = null!;
        public string Caputto { get; set; } = null!;
        public string Circular { get; set; } = null!;
        public string Lamniotico { get; set; } = null!;
        public string Miccion { get; set; } = null!;
        public string Meconio { get; set; } = null!;
        public string Pa { get; set; } = null!;
        public string Expulsivo { get; set; } = null!;
        public string Placenta { get; set; } = null!;
        public string Alumbramiento { get; set; } = null!;
        public string HuellaPlantar { get; set; } = null!;
        public DateTime CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public DateTime? DeleteAt { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? UpdateBy { get; set; }
        public Guid? DeleteBy { get; set; }
        [ForeignKey("PartographId")]
        public virtual PartographEntity Partograph { get; set; } = null!;
    }
}
