
namespace BirthflowService.Domain.Models.Log
{
    public class PartographLog
    {
        public required string Name { get; set; }
        public required string RecordName { get; set; }
        public required DateTime Date { get; set; }
        public required string Observation { get; set; }
        public required string WorkTime { get; set; }
    }
}
