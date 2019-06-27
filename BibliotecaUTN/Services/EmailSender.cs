using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;

using SendGrid;
using SendGrid.Helpers.Mail;

namespace BibliotecaUTN.Services
{
    public class EmailSender : IEmailSender
    {
        public EmailSender(IOptions<SendGridService> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }

        public SendGridService Options { get; }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            var send = Execute(Options.SendGridKey, subject, message, email);
            return send;
        }

        public Task Execute(string apiKey, string subject, string message, string email)
        {
            var client = new SendGridClient(apiKey);

            var msg = new SendGridMessage()
            {
                From = new EmailAddress("administracion@bibliotecautn.org", "Administración Biblioteca UTN"),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };

            msg.AddTo(new EmailAddress(email));
            msg.SetClickTracking(false, false);

            return client.SendEmailAsync(msg);
        }
    }
}
