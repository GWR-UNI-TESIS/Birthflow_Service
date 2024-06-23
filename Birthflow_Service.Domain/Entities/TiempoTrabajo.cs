using System;
using System.Collections.Generic;

namespace BirthflowMicroServices.Domain.Models;

public partial class TiempoTrabajo
{
    public string PartogramaId { get; set; } = null!;

    public string Posicion { get; set; } = null!;

    public string Paridad { get; set; } = null!;

    public string Membranas { get; set; } = null!;

    public DateTime CreateAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public virtual Partograma Partograma { get; set; } = null!;
}
