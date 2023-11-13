using Microsoft.AspNetCore.Mvc;

namespace SendEmail.Service.Interface
{
    public interface IService
    {
        public Task<IActionResult> CreateEmail();
    }
}
