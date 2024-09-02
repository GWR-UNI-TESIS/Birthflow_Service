using BirthflowService.Application.Utils.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthflowService.Application.Interfaces
{
    public interface IMailService
    {
        Task SendEmailAsync(SendEmailRequest sendEmailRequest);
    }
}
