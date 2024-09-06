using BirthflowService.Domain.DTOs.Contracts;

namespace BirthflowService.Domain.Interfaces
{
    public interface IMailAdapter
    {
        Task SendEmailAsync(SendEmailRequest sendEmailRequest);
    }
}
