using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthflowService.Domain.DTOs.Partograph
{
    public class PartographDto
    {
        public Guid? PartographId { get; set; } = null;
        public required string Name { get; set; }
        public required string RecordName { get; set; }
        public required DateTime Date { get; set; }
        public required string Observation { get; set; }
        public required string WorkTime { get; set; }
        public Guid? CreatedBy { get; set; }
    }
}
