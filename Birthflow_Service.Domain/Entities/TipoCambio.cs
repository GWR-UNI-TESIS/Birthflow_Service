using System;
using System.Collections.Generic;

namespace BirthflowMicroServices.Domain.Models;

public partial class TipoCambio
{
    public byte TipoCambioId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;
}
