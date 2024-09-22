using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BirthflowService.Domain.Entities;

[Table("Password", Schema = "Auth")]
public class PasswordEntity
{
    [Key]
    public long Id { get; set; }
    [ForeignKey("UserEntity")]
    public Guid UserId { get; set; }
    public string? PasswordHash { get; set; } = string.Empty;
    public bool? PassActual { get; set; }
    public DateTime CreateAt { get; set; }
    public virtual UserEntity? UserEntity { get; set; }
}
