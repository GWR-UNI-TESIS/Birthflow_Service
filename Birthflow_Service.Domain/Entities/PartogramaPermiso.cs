using System;
using System.Collections.Generic;

namespace BirthflowMicroServices.Domain.Models;

public partial class PartogramaPermiso
{
    public string PermisoPartogramaId { get; set; } = null!;

    public string? PartogramaId { get; set; }

    public Guid? UsuarioId { get; set; }

    public int? RolId { get; set; }

    public byte? TipoPermisoRolId { get; set; }

    public DateTime CreateAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public virtual Partograma? Partograma { get; set; }

    public virtual Role? Rol { get; set; }

    public virtual TipoPermisosRol? TipoPermisoRol { get; set; }

    public virtual Usuario? Usuario { get; set; }
}
