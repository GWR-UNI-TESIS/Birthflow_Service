using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birthflow_Domain.DTOs.Partographs
{
    public class FetalHeartRateDto
    {
        public int? Id { get; set; } = null;
        public Guid PartographId { get; set; }
        public string Value { get; set; } = null!;
        public DateTime Time { get; set; }

        public Guid? UserId { get; set; }
    }
}
