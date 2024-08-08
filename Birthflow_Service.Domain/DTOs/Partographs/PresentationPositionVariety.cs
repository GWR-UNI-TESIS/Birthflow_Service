using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birthflow_Domain.DTOs.Partographs
{
    public class PresentationPositionVariety
    {
        public int? Id { get; set; } = null;
        public Guid PartographId { get; set; }
        public string HodgePlane { get; set; } = null!;
        public string Position { get; set; } = null!;
        public DateTime Time { get; set; }
        public Guid? UserId { get; set; }
    }
}
