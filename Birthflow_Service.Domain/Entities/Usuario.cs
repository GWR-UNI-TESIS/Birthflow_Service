using System;
using System.Collections.Generic;

namespace BirthflowMicroServices.Domain.Models;

public partial class Usuario
{
    public Guid UsuarioId { get; set; }

    public string? Nombres { get; set; }

    public string? Apellidos { get; set; }

    public string? NombreUsuario { get; set; }

    public string? Email { get; set; }

    public decimal? PhoneNumber { get; set; }

    public int? RolId { get; set; }

    public bool IsDelete { get; set; }

    public DateTime CreateAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public DateTime? DeleteAt { get; set; }

    public virtual Configuracione? Configuracione { get; set; }

    public virtual ICollection<Notificatione> Notificationes { get; set; } = new List<Notificatione>();

    public virtual ICollection<PartogramaPermiso> PartogramaPermisos { get; set; } = new List<PartogramaPermiso>();

    public virtual ICollection<Partograma> Partogramas { get; set; } = new List<Partograma>();

    public virtual ICollection<Password> Passwords { get; set; } = new List<Password>();

    public virtual Role? Rol { get; set; }
}
