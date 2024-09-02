using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BirthflowMicroServices.Domain.Models;

[Table("User", Schema = "Auth")]
public class UserEntity
{
    [Key]
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? SecondName { get; set; }

    public string? UserName { get; set; }

    public string PasswordHash { get; set; } = string.Empty;

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
}
