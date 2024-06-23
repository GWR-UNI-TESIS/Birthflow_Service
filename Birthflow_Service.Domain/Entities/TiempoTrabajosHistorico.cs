using System;
using System.Collections.Generic;

namespace BirthflowMicroServices.Domain.Models;

public partial class TiempoTrabajosHistorico
{
    public long HistoricoId { get; set; }

    public string? PartogramaId { get; set; }

    public string Posicion { get; set; } = null!;

    public string Paridad { get; set; } = null!;

    public string Membranas { get; set; } = null!;

    public string? Accion { get; set; }

    public DateTime? FechaModificacion { get; set; }
}
