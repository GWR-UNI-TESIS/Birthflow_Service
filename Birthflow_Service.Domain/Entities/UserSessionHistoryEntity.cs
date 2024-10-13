using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BirthflowService.Domain.Entities
{
    [Table("UserSessionHistory", Schema = "Auth")]
    public class UserSessionHistoryEntity
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("UserEntity")]
        public Guid UserId { get; set; } // Relación con el usuario
        public DateTime SessionStartTime { get; set; } // Fecha y hora de inicio de la sesión
        public DateTime? SessionEndTime { get; set; } // Fecha y hora de finalización de la sesión (nullable para sesiones activas)
        public DateTime LastActivity { get; set; } // Propiedad para monitorear la última actividad
        public string IPAddress { get; set; } = string.Empty; // Dirección IP desde la cual se inició la sesión
        public string Device { get; set; } = string.Empty;
        public string SessionToken { get; set; } = string.Empty; // Token único de la sesión (por ejemplo, JWT o un token generado por la aplicación)
        public bool IsActive { get; set; } // Indica si la sesión está actualmente activa
        public virtual UserEntity? UserEntity { get; set; } // Relación de navegación con la tabla de usuarios
    }
}
