using System;
using System.Collections.Generic;

namespace BirthflowMicroServices.Domain.Models;

public partial class TipoNotificacione
{
    public byte TipoNotificacionesId { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Notificatione> Notificationes { get; set; } = new List<Notificatione>();
}
