using BirthflowMicroServices.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birthflow_Domain.Entities
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
        [MaxLength(3)]
        public string? WorkTime { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreatedAt { get; set; }
        [ForeignKey("UsuarioEntity")]
        public Guid? CreatedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public Guid? DeletedBy { get; set; }
        public UsuarioEntity? UsuarioEntity { get; set; }
    }
}
