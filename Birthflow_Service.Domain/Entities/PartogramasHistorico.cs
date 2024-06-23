using System;
using System.Collections.Generic;

namespace BirthflowMicroServices.Domain.Models;

public partial class PartogramasHistorico
{
    public long HistoricoId { get; set; }

    public string? PartogramaId { get; set; }

    public Guid? UsuarioId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Expediente { get; set; } = null!;

    public DateTime Fecha { get; set; }

    public string? Accion { get; set; }

    public DateTime? FechaModificacion { get; set; }
}
