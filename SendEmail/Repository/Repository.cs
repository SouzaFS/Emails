using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using SendEmail.Context;
using SendEmail.Model;
using SendEmail.Repository.Interface;

namespace SendEmail.Repository
{
    public class Repository : IRepository
    {
        public readonly AppDbContext _appDbContext;
        public readonly SmtpClient _smtpClient;
        public Repository(AppDbContext appDbContext, SmtpClient smtpClient)
        {
            _appDbContext = appDbContext;
            _smtpClient = smtpClient;
        }
        
        public async Task<IActionResult> CreateEmail()
        {
            return new ObjectResult(null) { StatusCode = StatusCodes.Status201Created };
        }
    }
}
