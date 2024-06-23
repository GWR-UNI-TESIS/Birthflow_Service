using System;
using System.Collections.Generic;

namespace BirthflowMicroServices.Domain.Models;

public partial class VigilanciaMedicaHistorico
{
    public long HistoricoId { get; set; }

    public string? VigilanciaMedicaId { get; set; }

    public string? PartogramaId { get; set; }

    public string? PosicionMaterna { get; set; }

    public string? PresionArterial { get; set; }

    public string? PulsoMaterno { get; set; }

    public string? FrecuenciaCardiacaFetal { get; set; }

    public string? DuracionContracciones { get; set; }

    public string? FrecuenciaContraciones { get; set; }

    public string? DolorIntensidad { get; set; }

    public string? DolorLocalizacion { get; set; }

    public DateTime? Tiempo { get; set; }

    public string? Accion { get; set; }

    public DateTime? FechaModificacion { get; set; }
}
