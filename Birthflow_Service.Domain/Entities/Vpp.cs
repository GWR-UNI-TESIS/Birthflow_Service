using System;
using System.Collections.Generic;

namespace BirthflowMicroServices.Domain.Models;

public partial class Vpp
{
    public string VppId { get; set; } = null!;

    public string? PartogramaId { get; set; }

    public string PlanoHodge { get; set; } = null!;

    public string Posicion { get; set; } = null!;

    public DateTime Tiempo { get; set; }

    public bool IsDelete { get; set; }

    public DateTime CreateAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public DateTime? DeleteAt { get; set; }

    public virtual Partograma? Partograma { get; set; }
}
