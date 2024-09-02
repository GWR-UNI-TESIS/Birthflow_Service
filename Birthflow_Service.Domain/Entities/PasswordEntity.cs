using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BirthflowMicroServices.Domain.Models;
[Table("Password", Schema = "Auth")]
public class PasswordEntity
{
    public int Id { get; set; }
    [ForeignKey("UserEntity")]
    public int? UsuarioId { get; set; }

    public string? PasswordHash { get; set; }

    public bool? PassActual { get; set; }

    public DateTime CreateAt { get; set; }

    public virtual UserEntity Usuario { get; set; }
}
