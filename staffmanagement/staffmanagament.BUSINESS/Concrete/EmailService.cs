using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using staffmanagament.BUSINESS.Interfaces;
using Microsoft.Extensions.Options;

namespace staffmanagament.BUSINESS.Concrete
{
    public class EmailService : IEmailService
    {
        private readonly SmtpClient _smtpClient;

        public EmailService(SmtpClient smtpClient)
        {
            _smtpClient = smtpClient;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            var mailMessage = new MailMessage("your-email@example.com", toEmail, subject, body);
            await _smtpClient.SendMailAsync(mailMessage);
        }
    }
}
