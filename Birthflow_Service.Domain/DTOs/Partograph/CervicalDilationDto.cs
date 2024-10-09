namespace BirthflowService.Domain.DTOs.Partograph
{
    public class CervicalDilationDto
    {
        public long? Id { get; set; } = null;
        public Guid PartographId { get; set; }
        public double Value { get; set; }
        public DateTime Hour { get; set; }
        public bool RemOrRam { get; set; }
    }
}
