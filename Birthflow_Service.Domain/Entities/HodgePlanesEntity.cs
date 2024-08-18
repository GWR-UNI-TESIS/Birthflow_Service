using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BirthflowService.Domain.Entities
{
    [Table("HodgePlanes", Schema = "Partograph")]
    public class HodgePlanesEntity
    {
        [Key]
        public int Id { get; set; }
        public required string Code { get; set; }
        public required string Description { get; set; }
    }
}