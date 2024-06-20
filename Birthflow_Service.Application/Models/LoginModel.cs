
using System.ComponentModel.DataAnnotations;

namespace Birthflow_Service.Application.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "User Name is required")]
        public required string Usuario { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public required string Contraseña { get; set; }
    }
}
