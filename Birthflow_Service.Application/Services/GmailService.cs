using BirthflowService.Domain.Options;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BirthflowService.Application.Interfaces;
using BirthflowService.Application.Utils.Contracts;

namespace BirthflowService.Application.Services
{
    public class GmailService : IMailService
    {
        private readonly GmailOptions _gmailOptions;

        public GmailService(IOptions<GmailOptions> gmailOptions)
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
