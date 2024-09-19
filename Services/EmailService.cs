using MimeKit;
using NETCore.MailKit.Core;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Intelliflo.Finance.Service.Helpers;

namespace Intelliflo.Finance.Service.Services
{
    public class EmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //public async Task SendEmailAsync(string toEmail, string subject, string body)
        //{
        //    var email = new MimeMessage();
        //    email.From.Add(new MailboxAddress(_configuration["MailSettings:SenderName"], _configuration["MailSettings:SenderEmail"]));
        //    email.To.Add(new MailboxAddress("", toEmail));
        //    email.Subject = subject;

        //    var builder = new BodyBuilder { HtmlBody = body };
        //    email.Body = builder.ToMessageBody();

        //    using (var smtp = new SmtpClient())
        //    {
        //        await smtp.ConnectAsync(_configuration["MailSettings:Server"], int.Parse(_configuration["MailSettings:Port"]), false);
        //        await smtp.AuthenticateAsync(_configuration["MailSettings:UserName"], _configuration["MailSettings:Password"]);
        //        await smtp.SendAsync(email);
        //        await smtp.DisconnectAsync(true);
        //    }
        //}
        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            // Create a new MimeMessage object for the email
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(_configuration["MailSettings:SenderName"], _configuration["MailSettings:SenderEmail"]));
            message.To.Add(new MailboxAddress("", toEmail));
            message.Subject = subject;

            // Set the body of the email
            message.Body = new TextPart("plain")
            {
                Text = body
            };

            using (var client = new SmtpClient())
            {
                try
                {
                    // Connect to the Papercut SMTP server on localhost
                    await client.ConnectAsync(_configuration["MailSettings:SmtpHost"], int.Parse(_configuration["MailSettings:SmtpPort"]), false);

                    // No need to authenticate for Papercut since it's local
                    // await client.AuthenticateAsync(_emailSettings.SenderEmail, _emailSettings.Password); // Not required

                    // Send the email
                    await client.SendAsync(message);

                    // Disconnect after sending
                    await client.DisconnectAsync(true);
                }
                catch (Exception ex)
                {
                    // Handle exceptions as needed
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }
    }
}
