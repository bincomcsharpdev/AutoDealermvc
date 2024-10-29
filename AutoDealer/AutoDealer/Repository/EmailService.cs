using AutoDealer.Interfaces;
using AutoDealer.Models;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;

namespace AutoDealer.Repository
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;

        public EmailService(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }
        public async Task SendEmail(EmailDto request)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Auto Dealer", _emailSettings.SenderEmail));
            message.To.Add(new MailboxAddress("", request.ToEmail));
            message.Subject = request.Subject;

            message.Body = new TextPart(TextFormat.Html)
            {
                Text = request.Body
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(_emailSettings.SmtpServer, _emailSettings.Port, MailKit.Security.SecureSocketOptions.StartTls);
                await client.AuthenticateAsync(_emailSettings.SenderEmail, _emailSettings.SenderPassword);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
        }
    }
}
