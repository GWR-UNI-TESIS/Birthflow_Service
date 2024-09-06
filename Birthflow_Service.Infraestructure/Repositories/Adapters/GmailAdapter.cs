using BirthflowService.Domain.Options;
using Microsoft.Extensions.Options;
using System.Net.Mail;
using System.Net;
using BirthflowService.Domain.Interfaces;
using BirthflowService.Domain.DTOs.Contracts;

namespace BirthflowService.Infraestructure.Repositories.Adapters
{
    public class GmailAdapter : IMailAdapter
    {
        private readonly GmailOptions _gmailOptions;

        public GmailAdapter(IOptions<GmailOptions> gmailOptions)
        {
            _gmailOptions = gmailOptions.Value;
        }

        public async Task SendEmailAsync(SendEmailRequest sendEmailRequest)
        {
            MailMessage mailMessage = new MailMessage
            {
                From = new MailAddress(_gmailOptions.Email),
                Subject = sendEmailRequest.Subject,
                Body = sendEmailRequest.Body
            };

            mailMessage.To.Add(sendEmailRequest.Recipient);

            mailMessage.IsBodyHtml = true;

            using var smtpClient = new SmtpClient();
            smtpClient.Host = _gmailOptions.Host;
            smtpClient.Port = _gmailOptions.Port;
            smtpClient.Credentials = new NetworkCredential(
                _gmailOptions.Email, _gmailOptions.Password);
            smtpClient.EnableSsl = true;

            await smtpClient.SendMailAsync(mailMessage);
        }
    }
}
