using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BirthflowService.Domain.Entities
{
    [Table("UserLoginAttempt", Schema = "Auth")]
    public class UserLoginAttemptEntity
    {
        [Key]
        public long Id { get; set; }
        [ForeignKey("UserEntity")]
        public Guid? UserId { get; set; } = null;// Relación con el usuario
        public DateTime AttemptTimestamp { get; set; } // Fecha y hora del intento de inicio de sesión
        public string IPAddress { get; set; } = string.Empty; // Dirección IP desde la cual se intentó iniciar sesión
        public bool Success { get; set; } // Indica si el intento de inicio de sesión fue exitoso o fallido
        public string? FailureReason { get; set; } = string.Empty; // (Opcional) Razón del fallo (si el intento fue fallido)
        public virtual UserEntity? UserEntity { get; set; } // Relación con la tabla de usuario
    }
}
