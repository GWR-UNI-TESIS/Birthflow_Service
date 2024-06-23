using System;
using System.Collections.Generic;

namespace BirthflowMicroServices.Domain.Models;

public partial class FrecuenciaCardiacaFetalHistorico
{
    public long HistoricoId { get; set; }

    public string? FrecuenciaCardiacaFetalId { get; set; }

    public string? PartogramaId { get; set; }

    public string? Valor { get; set; }

    public DateTime? Tiempo { get; set; }

    public string? Accion { get; set; }

    public DateTime? FechaModificacion { get; set; }
}
