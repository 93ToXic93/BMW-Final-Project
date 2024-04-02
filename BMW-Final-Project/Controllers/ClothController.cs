using BMW_Final_Project.Engine.Contracts;
using BMW_Final_Project.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace BMW_Final_Project.Controllers
{
    public class ClothController : BaseController
    {
        private readonly IClothService _service;

        public ClothController(IClothService service)
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
            var model = await _service.LoadByIdAsync(id);

            return View(model);

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
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> BuyCloth(int id)
        {
            try
            {
                await _service.AddAsync(id, User.Id());
                return RedirectToAction(nameof(AllBought));
            }
            catch (Exception e)
            {
                return RedirectToAction(nameof(Index));
            }

        }

        [HttpPost]
        public async Task<IActionResult> RemoveCloth(int id)
        {
            try
            {
                await _service.RemoveClothAsync(id);
                return RedirectToAction(nameof(AllBought));
            }
            catch (Exception e)
            {
                return NotFound();
            }

        }

        [HttpPost]
        public async Task<IActionResult> Force(int id)
        {

            try
            {
                await _service.BuyClothAsync(id);
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
                var cloths = await _service.GetAllMineClothsAsync(User.Id());

                return View(cloths);
        }

    }
}
