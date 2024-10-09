using BirthflowService.Domain.Models;

namespace BirthflowService.Domain.DTOs.Partograph
{
    public class PartographResponseDto
    {
        public Guid? PartographId { get; set; } = null;
        public required string Name { get; set; }
        public required string RecordName { get; set; }
        public required DateTime Date { get; set; }
        public string? Observation { get; set; }
        public required string WorkTime { get; set; }
        public IEnumerable<CervicalDilationDto>? CervicalDilations { get; set; }
        public IEnumerable<MedicalSurveillanceTableDto>? MedicalSurveillanceTable { get; set; }
        public IEnumerable<PresentationPositionVarietyDto>? PresentationPositionVarieties { get; set; }
        public IEnumerable<FetalHeartRateDto>? FetalHeartRates { get; set; }
        public IEnumerable<ContractionFrequencyDto>? contractionFrequencies { get; set; }
        public required PartographStateDto partographState { get; set; }
        public Curves? Curves { get; set; }
    }
}
