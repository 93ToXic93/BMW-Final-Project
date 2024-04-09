using BMW_Final_Project.Engine.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace BMW_Final_Project.Controllers
{
    public class AccessoriesController : BaseController
    {
        private readonly IAccessoriesService _accessoriesService;

        public AccessoriesController(IAccessoriesService eventService)
        {
            _accessoriesService = eventService;
        }


        public async Task<IActionResult> Index()
        {
            var model = await _accessoriesService.AllAccessoriesAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> LoadById(int id)
        {
            var model = await _accessoriesService.LoadByIdAsync(id);

            return View(model);

        }
    }
}
