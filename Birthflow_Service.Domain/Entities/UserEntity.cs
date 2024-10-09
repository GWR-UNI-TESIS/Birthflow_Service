using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BirthflowService.Domain.Entities;

[Table("User", Schema = "Auth")]
public class UserEntity
{
    [Key]
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? SecondName { get; set; }

    public string? UserName { get; set; }

    public string? Email { get; set; }
    [Column(TypeName = "decimal(8,0)")]
    public decimal? PhoneNumber { get; set; }

    public bool IsActive { get; set; }

    public bool IsDelete { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? DeletedAt { get; set; }

    public int? DeletedBy { get; set; }

    public virtual List<PasswordEntity> Passwords { get; set; } = new List<PasswordEntity>();
    public virtual ICollection<PartographStateEntity> PartographStateEntity { get; set; } = new List<PartographStateEntity>();
    public virtual ICollection<UserGroupEntity> UserGroupEntity { get; set; } = new List<UserGroupEntity>();
    public virtual ICollection<PartographShareEntity> PartographShareEntity { get; set; } = new List<PartographShareEntity>();
    public virtual ICollection<PartographGroupShareEntity> PartographGroupShares { get; set; } = new List<PartographGroupShareEntity>();
    public virtual ICollection<UserNotificationEntity> UserNotificationEntity { get; set; } = new List<UserNotificationEntity>();
    public virtual ICollection<UserLoginAttemptEntity>? LoginAttempts { get; set; } // Relación con intentos de inicio de sesión
    public virtual ICollection<UserSessionHistoryEntity>? SessionHistories { get; set; } // Relación con el historial de sesiones

}
