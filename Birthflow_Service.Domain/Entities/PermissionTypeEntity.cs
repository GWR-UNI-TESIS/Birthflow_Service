using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BirthflowService.Domain.Entities
{
    [Table("PermissionType", Schema = "Partograph")]
    public class PermissionTypeEntity
    {
        [Key]
        public int Id { get; set; }
        public Guid Identificator { get; set; }
        public required string Name {  get; set; }
        public string Description { get; set; } = null!;
        public DateTime CreateAt { get; set; }
    }
}
