using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthflowService.Domain.DTOs.Partograph
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
