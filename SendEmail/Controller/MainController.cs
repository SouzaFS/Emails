using Microsoft.AspNetCore.Mvc;
using SendEmail.Context;
using System.Net.Mail;

namespace SendEmail.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainController
    {
        public readonly AppDbContext _appDbContext;

        public MainController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            //_service = service;
        }

        [HttpPost]
        public Task<IActionResult> CreateEmail(int id, string emailSender, string emailReceiver, string emailTitle, string emailBody)
        {
            SmtpClient smtpClient = new SmtpClient("mail.MyWebsiteDomainName.com", 25);

            //smtpClient.Credentials = new System.Net.NetworkCredential(emailSender, "myIDPassword");
            smtpClient.UseDefaultCredentials = true; // uncomment if you don't want to use the network credentials
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.EnableSsl = true;
            MailMessage mail = new MailMessage();

            //Setting From , To and CC
            mail.From = new MailAddress(emailSender, "Remetente");
            mail.To.Add(new MailAddress(emailReceiver));
            //mail.CC.Add(new MailAddress(""));

            smtpClient.Send(mail);
        }

        
    }
}
