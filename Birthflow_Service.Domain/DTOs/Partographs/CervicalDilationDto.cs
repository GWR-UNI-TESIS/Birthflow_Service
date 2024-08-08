using Birthflow_Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birthflow_Domain.DTOs.Partographs
{
    public class CervicalDilationDto
    {
        public int? Id { get; set; } = null;
        public Guid PartographId { get; set; }
        public decimal Value { get; set; }
        public DateTime Hour { get; set; }
        public bool RemOrRam { get; set; }
        public Guid? UserId { get; set; }
    }
}
