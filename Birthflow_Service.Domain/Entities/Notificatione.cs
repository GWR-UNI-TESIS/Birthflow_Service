using System;
using System.Collections.Generic;

namespace BirthflowMicroServices.Domain.Models;

public partial class Notificatione
{
    public string NotificacionId { get; set; } = null!;

    public Guid? UsuarioId { get; set; }

    public byte? NotificationTypeId { get; set; }

    public bool Leido { get; set; }

    public DateTime Date { get; set; }

    public virtual TipoNotificacione? NotificationType { get; set; }

    public virtual Usuario? Usuario { get; set; }
}
