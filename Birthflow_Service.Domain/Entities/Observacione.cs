using System;
using System.Collections.Generic;

namespace BirthflowMicroServices.Domain.Models;

public partial class Observacione
{
    public string VigilanciaMedicaId { get; set; } = null!;

    public string Header { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public bool IsDelete { get; set; }

    public DateTime CreateAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public DateTime? DeleteAt { get; set; }

    public virtual VigilanciaMedica VigilanciaMedica { get; set; } = null!;
}
