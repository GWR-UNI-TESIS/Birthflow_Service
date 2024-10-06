
namespace BirthflowService.Domain.Models.Log
{
    public class CervicalDilationLog
    {
        public decimal Value { get; set; }
        public DateTime Hour { get; set; }
        public bool RemOrRam { get; set; }
    }
}
