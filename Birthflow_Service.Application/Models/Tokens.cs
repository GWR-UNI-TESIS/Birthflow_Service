namespace BirthflowService.Application.Models
{
    public class Tokens
    {
        public required string AccessToken { get; set; } 
        public required string RefreshToken { get; set; }
    }
}
