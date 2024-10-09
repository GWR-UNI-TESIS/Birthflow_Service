namespace BirthflowService.Domain.DTOs.Partograph
{
    public class FetalHeartRateDto
    {
        public int? Id { get; set; } = null;
        public Guid PartographId { get; set; }
        public string Value { get; set; } = null!;
        public DateTime Time { get; set; }
    }
}
