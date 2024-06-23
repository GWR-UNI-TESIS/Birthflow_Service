using System;
using System.Collections.Generic;

namespace BirthflowMicroServices.Domain.Models;

public partial class PartogramaHistorialCambio
{
    public string? PartogramaId { get; set; }

    public Guid? UsuarioId { get; set; }

    public byte? TipoCambioId { get; set; }

    public DateTime? Fecha { get; set; }

    public virtual Partograma? Partograma { get; set; }

    public virtual TipoCambio? TipoCambio { get; set; }

    public virtual Usuario? Usuario { get; set; }
}
