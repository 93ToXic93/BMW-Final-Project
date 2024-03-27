using BMW_Final_Project.Engine.Contracts;
using BMW_Final_Project.Extensions;
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
                await _service.AddAsync(id, User.Id());
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
                await _service.RemoveMotorcycleAsync(id);
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
            var motorcycles = await _service.GetAllMineMotorcyclesAsync(User.Id());

            return View(motorcycles);
        }

        [HttpPost]
        public async Task<IActionResult> Force(int id)
        {

            try
            {
                await _service.BuyMotorcycleAsync(id);
                return RedirectToAction(nameof(AllBought));
            }
            catch (Exception e)
            {
                return NotFound();
            }

        }

        

    }
}
