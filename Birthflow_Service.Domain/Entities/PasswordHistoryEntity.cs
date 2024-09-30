using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace BirthflowService.Domain.Entities
{
    [Table("PasswordHistory", Schema = "Auth")]
    public class PasswordHistoryEntity
    {
        [Key]
        public long Id { get; set; }
        [ForeignKey("UserEntity")]
        public Guid UserId { get; set; } // Relación con el usuario
        public string? OldPasswordHash { get; set; } = string.Empty; // Contraseña anterior
        public DateTime ChangedDate { get; set; } // Fecha de cambio
        public virtual UserEntity? UserEntity { get; set; }
    }
}
