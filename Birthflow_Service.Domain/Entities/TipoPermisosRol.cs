using System;
using System.Collections.Generic;

namespace BirthflowMicroServices.Domain.Models;

public partial class TipoPermisosRol
{
    public byte TipoPermisoRolId { get; set; }

    public string? Nombre { get; set; }

    public DateTime CreateAt { get; set; }

    public virtual ICollection<PartogramaPermiso> PartogramaPermisos { get; set; } = new List<PartogramaPermiso>();
}
