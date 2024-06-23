using System;
using System.Collections.Generic;

namespace BirthflowMicroServices.Domain.Models;

public partial class ObservacionesHistorico
{
    public long HistoricoId { get; set; }

    public string? VigilanciaMedicaId { get; set; }

    public string? Header { get; set; }

    public string? Descripcion { get; set; }

    public bool? IsDelete { get; set; }

    public DateTime? CreateAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public DateTime? DeleteAt { get; set; }

    public string? Accion { get; set; }

    public DateTime? FechaModificacion { get; set; }
}
