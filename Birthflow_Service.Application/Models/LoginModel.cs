
using System.ComponentModel.DataAnnotations;

namespace Birthflow_Service.Application.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "User Name is required")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public required string Password { get; set; }
    }
}
