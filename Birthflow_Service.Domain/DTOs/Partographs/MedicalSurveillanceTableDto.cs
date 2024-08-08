using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birthflow_Domain.DTOs.Partographs
{
    public class MedicalSurveillanceTabledTO
    {
        public int? Id { get; set; } = null;
        public Guid PartographId { get; set; }
        public string MaternalPosition { get; set; } = null!;
        public string ArterialPressure { get; set; } = null!;
        public string MaternalPulse { get; set; } = null!;
        public string FetalHeartRate { get; set; } = null!;
        public string ContractionsDuration { get; set; } = null!;
        public string FrequencyContractions { get; set; } = null!;
        public string Pain { get; set; } = null!;
        public DateTime Time { get; set; }

        public Guid? UserId { get; set; }
    }
}
