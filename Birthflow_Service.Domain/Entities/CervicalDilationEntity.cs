using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthflowService.Domain.Entities
{
    [Table("CervicalDilations", Schema = "Partograph")]
    public class CervicalDilationEntity
    {
        [Key, Column(TypeName = "bigint")]
        public long Id { get; set; }
        [ForeignKey("PartographEntity")]
        public Guid PartographId { get; set; }
        public double Value { get; set; }
        public DateTime Hour { get; set; }
        public bool RemOrRam { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public DateTime? DeleteAt { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? UpdateBy { get; set; }
        public Guid? DeleteBy { get; set; }
        public virtual PartographEntity? Partograph { get; set; }
    }
}
