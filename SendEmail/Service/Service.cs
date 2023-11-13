using Microsoft.AspNetCore.Mvc;
using SendEmail.Repository.Interface;
using SendEmail.Service.Interface;

namespace SendEmail.Service
{
    public class Service : IService
    {
        private readonly IRepository _repository;

        public Service(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> CreateEmail()
        {
            return await _repository.CreateEmail();
        }
    }
}
