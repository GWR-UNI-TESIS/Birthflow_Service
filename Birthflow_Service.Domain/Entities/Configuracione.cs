using System;
using System.Collections.Generic;

namespace BirthflowMicroServices.Domain.Models;

public partial class Configuracione
{
    public Guid UsuarioId { get; set; }

    public bool? PermisoNotificacion { get; set; }

    public bool? PermisoVibracion { get; set; }

    public string? Lenguaje { get; set; }

    public DateTime CreateAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public virtual Usuario Usuario { get; set; } = null!;
}
