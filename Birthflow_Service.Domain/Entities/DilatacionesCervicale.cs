using System;
using System.Collections.Generic;

namespace BirthflowMicroServices.Domain.Models;

public partial class DilatacionesCervicale
{
    public string DilatacionCervicalId { get; set; } = null!;

    public string? PartogramaId { get; set; }

    public decimal Valor { get; set; }

    public DateTime Hora { get; set; }

    public bool RemOram { get; set; }

    public bool IsDelete { get; set; }

    public DateTime CreateAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public DateTime? DeleteAt { get; set; }

    public virtual Partograma? Partograma { get; set; }
}
