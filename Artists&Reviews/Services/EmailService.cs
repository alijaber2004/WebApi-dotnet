using Artists_Reviews.Interface;
using System.Net;
using System.Net.Mail;

namespace Artists_Reviews.Services
{
    public class EmailService : IEmailService
    {
        public Task SendEmailAsync(string Email, string subject, string message)
        {
            var mail = "ali.jaber.k.683@gmail.com";
            var pw = "ALIali2004";

            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(mail, pw)

            };

            return client.SendMailAsync(
                new MailMessage(from: mail,
                to: Email,
                subject,
                message));
        }
    }

}
