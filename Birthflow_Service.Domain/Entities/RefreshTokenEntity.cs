using BirthflowMicroServices.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BirthflowService.Domain.Entities
{
    [Table("RefreshToken", Schema = "Auth")]
    public class RefreshTokenEntity
    {
        [Key]
        public int RefreshTokenId { get; set; }
        public string RefreshTokenValue { get; set; }
        public bool Active { get; set; }
        public DateTime Expiration { get; set; }
        public bool Used { get; set; }
        [Required, ForeignKey("UserEntity")]
        public Guid UserId { get; set; }
        public virtual UserEntity? User { get; set; }
    }
}
