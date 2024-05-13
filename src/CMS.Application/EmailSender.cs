using CMS.Application.UseCases.EmailService;
using CMS.Domain.Entities.Models;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace EmailSenderApp.Application.Services.EmailServces
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public async Task SendEmailAsync(EmailModel model)
        {
            var emailSettings = _config.GetSection("EmailSettings");

            // Read HTML content from the file
            string path = @"D:\SelfStudy\frontend\versitka\planeta\sender.html";
            string htmlBody;
            using (var streamReader = new StreamReader(path))
            {
                htmlBody = await streamReader.ReadToEndAsync();
            }

            // Set up the MailMessage object
            var mailMessage = new MailMessage
            {
                From = new MailAddress(emailSettings["Sender"], emailSettings["SenderName"]),
                Subject = model.Subject,
                Body = htmlBody, // Set HTML body here
                IsBodyHtml = true,
            };
            mailMessage.To.Add(model.To);

            // Configure and send email using SmtpClient
            using (var smtpClient = new SmtpClient(emailSettings["MailServer"], int.Parse(emailSettings["MailPort"])))
            {
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.Credentials = new NetworkCredential(emailSettings["Sender"], emailSettings["Password"]);
                smtpClient.EnableSsl = true;

                await smtpClient.SendMailAsync(mailMessage);
            }
        }
    }
}
