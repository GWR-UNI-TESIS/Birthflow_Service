namespace Birthflow_Application.DTOs.Auth
{
    public class UsuarioEntityDto
    {
        public Guid? Id { get; set; }

        public string? Nombres { get; set; }

        public string? Apellidos { get; set; }

        public string? NombreUsuario { get; set; }

        public string? Email { get; set; }

        public decimal? PhoneNumber { get; set; }

        public string? PasswordHash { get; set; }

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

        public class UserLoginDto
        {
            public string AccessToken { get; set; }
            public string RefreshToken { get; set; }
            public UsuarioEntityDto User { get; set; }
        }
    }
}