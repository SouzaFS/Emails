using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using SendEmail.Context;
using SendEmail.DTOs;
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

        [HttpPost]
        public async Task<IActionResult> CreateEmail(EmailDTO emailDTO)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Sender", emailDTO.EmailSender));
            message.To.Add(new MailboxAddress("Receiver", emailDTO.EmailReceiver));
            message.Subject = emailDTO.EmailSubject;
            message.Body = new TextPart("plain")
            {
                Text = emailDTO.EmailBody
            };
            using (var client = new SmtpClient())
            {
                client.Connect("smtp.office365.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                client.Authenticate(emailDTO.EmailSender, emailDTO.EmailPassword);
                client.Send(message);
                client.Disconnect(true);
            }
            return Ok(new {success = true, data = emailDTO});

        }

        
    }
}
