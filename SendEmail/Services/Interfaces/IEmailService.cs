using SendEmail.Model;
using System.Net.Mail;

namespace SendEmail.Services.Interfaces
{
    public interface IEmailService
    {
        public Email CreateEmailType(string emailType, User user);
        public MailMessage CreateMessageFormat(Email email);
        public SmtpClient? CreateSmptClient(string emailCredentials, Email email);
    }
}
