using BMW_Final_Project.Core.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BMW_Final_Project.Controllers
{
    public class MotorcycleController : BaseController
    {
        private readonly IMotorcycleService _service;

        public MotorcycleController(IMotorcycleService service)
        {
            _service = service;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var model = await _service.AllAsync();

            return View(model);
        }
    }
}
