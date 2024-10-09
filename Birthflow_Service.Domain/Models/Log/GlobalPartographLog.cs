
namespace BirthflowService.Domain.Models.Log
{
    public class GlobalPartographLog
    {
        public PartographLog? partographLog { get; set; }
        public IEnumerable<CervicalDilationLog> cervicalDilationLog { get; set; } = new List<CervicalDilationLog>();
        public IEnumerable<MedicalSurveillanceTableLog> medicalSurveillanceTableLog { get; set; } = new List<MedicalSurveillanceTableLog>();
        public IEnumerable<PresentationPositionVarietyLog> presentationPositionVarietyLog { get; set; } = new List<PresentationPositionVarietyLog>();
        public IEnumerable<ContractionFrequencyLog> contractionFrequencyLog { get; set; } = new List<ContractionFrequencyLog>();
        public IEnumerable<FetalHeartRateLog> fetalHeartRateLog { get; set; } = new List<FetalHeartRateLog>();
        public ChildbirthNoteLog? childbirthNoteLog { get; set; }
        public Curves? curves { get; set; }
    }
}
