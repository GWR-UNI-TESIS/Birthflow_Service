using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BirthflowService.Domain.Entities
{
    [Table("Positions", Schema = "Partograph")]
    public class PositionEntity
    {
        [Key]
        public int Id { get; set; }
        public required string Code { get; set; }
        public required string Description { get; set; }
    }
}