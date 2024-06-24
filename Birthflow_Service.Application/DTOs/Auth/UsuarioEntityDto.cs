using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birthflow_Application.DTOs.Auth
{
    public class UsuarioEntityDto
    {
        public int Id { get; set; }

        public string? Nombres { get; set; }

        public string? Apellidos { get; set; }

        public string? NombreUsuario { get; set; }

        public string? Email { get; set; }

        public decimal? PhoneNumber { get; set; }

        public int? RolId { get; set; }

        public bool IsDelete { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }
    }

    public class UsersSummary
    {
        public int AllUser { get; set; }
        public int ActiveUser { get; set; }
        public int InactiveUser { get; set; }
        public int NewUsers { get; set; }
    }

    public class UserDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
