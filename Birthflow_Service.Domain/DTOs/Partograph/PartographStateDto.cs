namespace BirthflowService.Domain.DTOs.Partograph
{
    public class PartographStateDto
    {
        public Guid PartographId { get; set; }
        public bool IsAchived { get; set; }
        public bool Set { get; set; }
        public bool Silenced { get; set; }
        public bool Favorite { get; set; }
    }
}
