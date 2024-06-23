using System;
using System.Collections.Generic;

namespace BirthflowMicroServices.Domain.Models;

public partial class DilatacionesCervicalesHistorico
{
    public long HistoricoId { get; set; }

    public string? DilatacionCervicalId { get; set; }

    public string? PartogramaId { get; set; }

    public decimal? Valor { get; set; }

    public DateTime? Hora { get; set; }

    public bool? RemOram { get; set; }

    public string? Accion { get; set; }

    public DateTime? FechaModificacion { get; set; }
}
