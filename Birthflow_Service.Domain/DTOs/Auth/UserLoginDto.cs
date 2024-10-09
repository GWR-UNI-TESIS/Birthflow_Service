using Birthflow_Application.DTOs.Auth;

namespace BirthflowService.Domain.DTOs.Auth
{
    public class UserLoginDto
    {
        public required string AccessToken { get; set; }
        public required string RefreshToken { get; set; }
        public UserDto? User { get; set; }
    }
}
