using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birthflow_Domain.DTOs.Partographs
{
    public class ContractionFrequencyDto
    {
        public int? Id { get; set; } = null;
        public Guid PartographId { get; set; }
        public int Value { get; set; }
        public DateTime Time { get; set; }
    }
}
