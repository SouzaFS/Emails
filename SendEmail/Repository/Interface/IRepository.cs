using Microsoft.AspNetCore.Mvc;

namespace SendEmail.Repository.Interface
{
    public interface IRepository
    {
        public Task<IActionResult> CreateEmail();
    }
}
