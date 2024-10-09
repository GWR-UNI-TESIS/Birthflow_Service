using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BirthflowService.Domain.Entities
{
    [Table("ActivationToken", Schema = "Auth")]
    public class ActivationTokenEntity
    {
        [Key]
        public int Id { get; set; }
        public required string Email { get; set; }
        public required string Value { get; set; }
        public DateTime Expiration { get; set; }
    }
}
