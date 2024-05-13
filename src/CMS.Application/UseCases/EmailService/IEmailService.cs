using CMS.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.EmailService
{
    public interface IEmailService
    {
        public Task SendEmailAsync(EmailModel email);
    }
}
