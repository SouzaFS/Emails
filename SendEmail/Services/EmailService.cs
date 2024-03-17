using Microsoft.AspNetCore.Mvc.ModelBinding;
using SendEmail.Model;
using SendEmail.Services.Interfaces;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace SendEmail.Services
{
    public class EmailService : IEmailService
    {
        public EmailService()
        {

        }

        public Email CreateEmailType (string emailType, User user)
        {
            var email = new Email()
            {
                EmailSender = "email",
                EmailPassword = "password",
                EmailReceiver = user.UserEmail
            };

            if (emailType == "CodeValidation")
            {

                Random random = new Random();
                email.CodeValidation = random.Next(10000, 99999);

                email.EmailSubject = "Password Recovering";
                email.EmailBody = $@"
                    <!DOCTYPE html>
                    <html lang=""pt"">
                    <head>
                        <meta charset=""UTF-8"">
                        <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                        <title>Password Recovering</title>
                    </head>
                    <body style=""font-family: Arial, sans-serif;"">
        
                        <h2>Password Recovering</h2>
                        <p>Dear {user.UserName},</p>

                        <p>We're sorry to know you're having trouble accessing your account. To retrieve your access fully, please enter the following verification code:</p>

                        <div style=""padding: 10px; background-color: #f2f2f2; border-radius: 5px; font-size: 18px; font-weight: bold; text-align: center;"">
                            {email.CodeValidation}
                        </div>  

                        <p>This code is valid for a limited time. Please do not share it with anyone for security reasons.</p>

                        <p>If you did not attempt to retrieve your password, please contact us as soon as possible to verify the circumstances of a possible breach.</p>

                        <p>Best Regards, <br>Só Carrinhos</p>

                    </body>
                    </html>
                ";


            }
            else if (emailType == "AnnouncementCreated")
            {

                email.EmailSubject = "";
                email.EmailBody = "";

            }
            else if (emailType == "AnnouncementChat")
            {

                email.EmailSubject = "";
                email.EmailBody = "";

            }

            return email;
        }

        public MailMessage CreateMessageFormat(Email email)
        {

            MailMessage message = new MailMessage()
            {
                From = new MailAddress(email.EmailSender),
                Subject = email.EmailSubject,
                Body = email.EmailBody,
                IsBodyHtml = true
            };

            message.To.Add(new MailAddress(email.EmailReceiver));

            return message;
        }

        public SmtpClient? CreateSmptClient(string emailCredentials, Email email)
        {
            if (emailCredentials == "office365")
            {
                SmtpClient smtpClient = new SmtpClient("smtp.office365.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential(email.EmailSender, email.EmailPassword),
                    EnableSsl = true
                };

                return smtpClient;
            }
            else
            {
                return null;
            }
        }
    }
}
