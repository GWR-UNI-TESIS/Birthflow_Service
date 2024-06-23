using System;
using System.Collections.Generic;

namespace BirthflowMicroServices.Domain.Models;

public partial class NotificationPartograma
{
    public string? PartogramaId { get; set; }

    public Guid? UsuarioId { get; set; }

    public string? NotificacionId { get; set; }

    public virtual Notificatione? Notificacion { get; set; }

    public virtual Partograma? Partograma { get; set; }

    public virtual Usuario? Usuario { get; set; }
}
