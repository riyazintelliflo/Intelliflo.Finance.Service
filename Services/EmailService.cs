using NETCore.MailKit.Core;

namespace Intelliflo.Finance.Service.Services
{
    public class EmailService
    {
        private readonly IEmailService _emailService;

        public EmailService(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            await _emailService.SendAsync(toEmail, subject, body, isHtml: true);
        }
    }
}
