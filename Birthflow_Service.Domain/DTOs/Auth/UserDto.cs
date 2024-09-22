namespace Birthflow_Application.DTOs.Auth
{
    public class UserDto
    {
        public Guid? Id { get; set; }

        public string? Name { get; set; }

        public string? SecondName { get; set; }

        public string? UserName { get; set; }

        public string? Email { get; set; }

        public decimal? PhoneNumber { get; set; }

        public string? PasswordHash { get; set; }
    }
}