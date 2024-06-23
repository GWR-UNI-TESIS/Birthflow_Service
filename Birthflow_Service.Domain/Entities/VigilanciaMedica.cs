using System;
using System.Collections.Generic;

namespace BirthflowMicroServices.Domain.Models;

public partial class VigilanciaMedica
{
    public string VigilanciaMedicaId { get; set; } = null!;

    public string? PartogramaId { get; set; }

    public string PosicionMaterna { get; set; } = null!;

    public string PresionArterial { get; set; } = null!;

    public string PulsoMaterno { get; set; } = null!;

    public string FrecuenciaCardiacaFetal { get; set; } = null!;

    public string DuracionContracciones { get; set; } = null!;

    public string FrecuenciaContraciones { get; set; } = null!;

    public string DolorIntensidad { get; set; } = null!;

    public string DolorLocalizacion { get; set; } = null!;

    public DateTime Tiempo { get; set; }

    public bool IsDelete { get; set; }

    public DateTime CreateAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public DateTime? DeleteAt { get; set; }

    public virtual Observacione? Observacione { get; set; }

    public virtual Partograma? Partograma { get; set; }
}
