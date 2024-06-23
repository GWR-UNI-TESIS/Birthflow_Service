using System;
using System.Collections.Generic;

namespace BirthflowMicroServices.Domain.Models;

public partial class NotaPartoHistorico
{
    public long HistoricoId { get; set; }

    public string? PartogramaId { get; set; }

    public string? Descripcion { get; set; }

    public string? Hora { get; set; }

    public string? Sexo { get; set; }

    public string? Apgar { get; set; }

    public string? Temperatura { get; set; }

    public string? Caputto { get; set; }

    public string? Circular { get; set; }

    public string? Lamniotico { get; set; }

    public string? Miccion { get; set; }

    public string? Meconio { get; set; }

    public string? Pa { get; set; }

    public string? Expulsivo { get; set; }

    public string? Placenta { get; set; }

    public string? Alumbramiento { get; set; }

    public string? HuellaPlantar { get; set; }

    public DateTime? Date { get; set; }

    public string? Accion { get; set; }

    public DateTime? FechaModificacion { get; set; }
}
