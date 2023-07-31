using Common.Model;
using Microsoft.Extensions.Options;
using MailKit.Net.Smtp;
using MimeKit;
using MailKit.Security;

namespace Services.Email
{
    public class EmailService : IEmailService
    {
        private readonly EmailConfiguration emailConfiguration;
        public EmailService(IOptions<EmailConfiguration> options)
        {
            this.emailConfiguration = options.Value;
        }
        public async Task SendEmailAsync(MailRequest mailRequest)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(emailConfiguration.Email);
            email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
            email.Subject = mailRequest.Subject;
            var builder = new BodyBuilder();
            builder.HtmlBody = mailRequest.Body;
            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();
            smtp.Connect(emailConfiguration.Host, emailConfiguration.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(emailConfiguration.Email, emailConfiguration.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }
    }
}
