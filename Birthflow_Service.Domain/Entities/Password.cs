using System;
using System.Collections.Generic;

namespace BirthflowMicroServices.Domain.Models;

public partial class Password
{
    public Guid PasswordId { get; set; }

    public Guid? UsuarioId { get; set; }

    public byte[]? PasswordHash { get; set; }

    public byte[]? PasswordSalt { get; set; }

    public bool? PassActual { get; set; }

    public DateTime CreateAt { get; set; }

    public virtual Usuario? Usuario { get; set; }
}
