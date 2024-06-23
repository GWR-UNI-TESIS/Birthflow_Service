using System;
using System.Collections.Generic;

namespace BirthflowMicroServices.Domain.Models;

public partial class FrecuenciaContracionesHistorico
{
    public long HistoricoId { get; set; }

    public string? FrecuenciaContracionesId { get; set; }

    public string? PartogramaId { get; set; }

    public string? Valor { get; set; }

    public DateTime? Tiempo { get; set; }

    public string? Accion { get; set; }

    public DateTime? FechaModificacion { get; set; }
}
