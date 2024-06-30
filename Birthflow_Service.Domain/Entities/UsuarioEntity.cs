using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BirthflowMicroServices.Domain.Models;

[Table("Usuario", Schema = "Auth")]
public class UsuarioEntity
{
    [Key]
    public int Id { get; set; }

    public string? Nombres { get; set; }

    public string? Apellidos { get; set; }

    public string? NombreUsuario { get; set; }

    public string PasswordHash { get; set; } = string.Empty;

    public string? Email { get; set; }

    public decimal? PhoneNumber { get; set; }

    public bool IsDelete { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? DeletedAt { get; set; }

    public int? DeletedBy { get; set; }

    public virtual List<PasswordEntity> Passwords { get; set; } = new List<PasswordEntity>();
}
