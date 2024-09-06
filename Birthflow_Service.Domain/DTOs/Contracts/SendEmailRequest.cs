using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthflowService.Domain.DTOs.Contracts
{
    public record SendEmailRequest(string Recipient, string Subject, string Body);
}
