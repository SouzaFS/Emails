using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using SendEmail.Context;
using SendEmail.Model;

namespace SendEmail.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        public readonly AppDbContext _appDbContext;
        //public readonly ISmtpClient _smtpClient;
        public MainController(AppDbContext appDbContext)//, ISmtpClient smtpClient)
        {
            _appDbContext = appDbContext;
            //_smtpClient = smtpClient;
            //_service = service;
        }

        [HttpGet]
        public async Task<IActionResult> CreateEmail()
        {
            EmailModel emailModel = new EmailModel
            {
                EmailSender = "",
                EmailBody = "Só pra você saber que eu enviei esse email via Desenvolvimento Web (foi pro spam provavelmente)",
                EmailSubject = "Email enviado por programação",
                EmailReceiver = "@gmail.com",
                EmailPassword = ""
            };
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("", emailModel.EmailSender));
            message.To.Add(new MailboxAddress("", emailModel.EmailReceiver));
            message.Subject = emailModel.EmailSubject;
            message.Body = new TextPart("plain")
            {
                Text = emailModel.EmailBody
            };
            using (var client = new SmtpClient())
            {
                client.Connect("smtp.office365.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                client.Authenticate(emailModel.EmailSender, emailModel.EmailPassword);
                client.Send(message);
                client.Disconnect(true);
            }
            return Ok(new {success = true, data = emailModel});

        }

        
    }
}
