
namespace BirthflowService.Domain.DTOs.Partograph
{
    public class PresentationPositionVarietyDto
    {
        public int Id { get; set; }
        public Guid PartographId { get; set; }
        public int HodgePlane { get; set; }
        public int Position { get; set; } 
        public DateTime Time { get; set; }
    }
}
