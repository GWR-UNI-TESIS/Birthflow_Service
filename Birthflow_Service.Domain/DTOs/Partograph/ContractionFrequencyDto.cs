using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthflowService.Domain.DTOs.Partograph
{
    public class ContractionFrequencyDto
    {
        public int? Id { get; set; } = null;
        public Guid PartographId { get; set; }
        public int Value { get; set; }
        public DateTime Time { get; set; }
        public Guid? UserId { get; set; }
    }
}
