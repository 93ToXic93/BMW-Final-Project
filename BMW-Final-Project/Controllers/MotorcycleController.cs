using BMW_Final_Project.Engine.Contracts;
using BMW_Final_Project.Engine.Models.Motorcycle;
using BMW_Final_Project.Infrastructure.Data.Models.Motorcycles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> Index()
        {
            var model = await _service.AllAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> LoadById(int id)
        {
            try
            {
                var model = await _service.LoadById(id);

                return View(model);
            }
            catch (Exception e)
            {
                //TO DO THE EXCEPTION!

                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var model = await _service.DetailsAsync(id);
                return View(model);
            }
            catch (Exception e)
            {
                //TO DO THE EXCEPTION
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> BuyMotorcycle(int id)
        {
            try
            {
                await _service.AddAsync(id, GetUserId());
                return RedirectToAction(nameof(AllBought));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPost]
        public async Task<IActionResult> RemoveMotorcycle(int id)
        {
            try
            {
                await _service.RemoveMotorcycle(id);
                return RedirectToAction(nameof(AllBought));
            }
            catch (Exception e)
            {
                return NotFound();
            }

        }

        [HttpGet]
        public async Task<IActionResult> AllBought()
        {
            var motorcycles = await _service.GetAllMineMotorcyclesAsync(GetUserId());

            return View(motorcycles);
        }

        [HttpPost]
        public async Task<IActionResult> Force()
        {

            return RedirectToAction(nameof(AllBought));
        }

    }
}
