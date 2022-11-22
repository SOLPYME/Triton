using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using Triton.Common.EMail.Contracts.Infrastructure;
using Triton.Common.EMail.Models;
using EmailModel = Triton.Common.EMail.Models.Email;

namespace Triton.Core.Infrastructure.Email
{
    public class EmailService : IEmailService
    {
        public EmailSettings _EmailSettings { get; }
        public ILogger<EmailService> _Logger { get; }

        public EmailService(IOptions<EmailSettings> emailSettings, ILogger<EmailService> logger)
        {
            _EmailSettings = emailSettings.Value;
            _Logger = logger;
        }
        public async Task<bool> SendEmail(EmailModel email)
        {
            var client = new SendGridClient(_EmailSettings.ApiKey);
            var subject = email.Subject;
            var to = new EmailAddress(email.To);
            var emailBody = email.Body;
            var from = new EmailAddress
            {
                Email = _EmailSettings.FromAddress,
                Name = _EmailSettings.FromName
            };
            var sendGridMessage = MailHelper.CreateSingleEmail(from, to, subject, emailBody, emailBody);
            var response = await client.SendEmailAsync(sendGridMessage);
            if (response.StatusCode == System.Net.HttpStatusCode.Accepted || response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            _Logger.LogError("El email no pudo enviarse, existen errores");
            return false;
        }
    }
}
