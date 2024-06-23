using System;
using System.Collections.Generic;

namespace BirthflowMicroServices.Domain.Models;

public partial class PartogramaEstado
{
    public string PartogramaId { get; set; } = null!;

    public bool Archivado { get; set; }

    public bool Silenciado { get; set; }

    public bool Permanente { get; set; }

    public DateTime UltimaModificacion { get; set; }

    public bool DilatacionCervicalesNotificacion { get; set; }

    public bool PlanoHodgeNotificacion { get; set; }

    public bool VigilanciaMedicaNotificacion { get; set; }

    public bool Fcfydcnotificacion { get; set; }

    public byte? TipoPermisoId { get; set; }

    public DateTime CreateAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public virtual Partograma Partograma { get; set; } = null!;

    public virtual TipoPermiso? TipoPermiso { get; set; }
}
