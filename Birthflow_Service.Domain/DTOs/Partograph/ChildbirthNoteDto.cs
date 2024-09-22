using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthflowService.Domain.DTOs.Partograph
{
    public class ChildbirthNoteDto
    {
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
    }
}
