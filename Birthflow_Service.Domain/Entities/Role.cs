using System;
using System.Collections.Generic;

namespace BirthflowMicroServices.Domain.Models;

public partial class Role
{
    public int RolId { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<PartogramaPermiso> PartogramaPermisos { get; set; } = new List<PartogramaPermiso>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
