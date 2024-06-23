using System;
using System.Collections.Generic;

namespace BirthflowMicroServices.Domain.Models;

public partial class TipoPermiso
{
    public byte TipoPermisoId { get; set; }

    public string? Nombre { get; set; }

    public DateTime CreateAt { get; set; }

    public virtual ICollection<PartogramaEstado> PartogramaEstados { get; set; } = new List<PartogramaEstado>();
}
