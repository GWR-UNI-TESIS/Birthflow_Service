using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BirthflowService.Domain.Entities
{
    [Table("SystemConfiguration", Schema = "Partograph")]
    public class SystemConfigurationEntity
    {
        [Key]
        public int Id { get; set; }
        public required string Key { get; set; }
        public string Description { get; set; } = null!;
        public string Value { get; set; } = null!;
        public DateTime CreateAt { get; set; }
    }
}
