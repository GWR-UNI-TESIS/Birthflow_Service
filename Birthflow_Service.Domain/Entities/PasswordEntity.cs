using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BirthflowMicroServices.Domain.Models;
[Table("Password", Schema = "Auth")]
public class PasswordEntity
{
    public int Id { get; set; }
    [ForeignKey("UsuarioEntity")]
    public int? UsuarioId { get; set; }

    public string? PasswordHash { get; set; }

    public bool? PassActual { get; set; }

    public DateTime CreateAt { get; set; }

    public virtual UsuarioEntity Usuario { get; set; }
}
