namespace BirthflowService.Domain.DTOs.Partograph
{
    public class ContractionFrequencyDto
    {
        public int? Id { get; set; } = null;
        public Guid PartographId { get; set; }
        public int Value { get; set; }
        public DateTime Time { get; set; }
    }
}
