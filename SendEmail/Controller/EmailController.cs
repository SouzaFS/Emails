using Microsoft.AspNetCore.Mvc;
using SendEmail.Model;
using SendEmail.Services.Interfaces;
using System.Net;
using System.Net.Mail;

namespace SendEmail.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;
        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost]
        public IActionResult CreateEmail(string emailType, string emailCredentials, User user)
        {
            Email email = _emailService.CreateEmailType(emailType, user);

            MailMessage message = _emailService.CreateMessageFormat(email);

            SmtpClient? smtpClient = _emailService.CreateSmptClient(emailCredentials, email);

            try {
                smtpClient?.Send(message);
                return Ok(new
                {
                    success = true,
                    data = email.CodeValidation
                });
            }
            catch (Exception e)
            {
                return Problem(null, null, 500);
            }


        }


    }
}
