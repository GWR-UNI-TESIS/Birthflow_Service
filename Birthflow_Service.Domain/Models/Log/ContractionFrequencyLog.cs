
namespace BirthflowService.Domain.Models.Log
{
    public class ContractionFrequencyLog
    {
        public Guid PartographId { get; set; }
        public int Value { get; set; }
        public DateTime Time { get; set; }
    }
}
