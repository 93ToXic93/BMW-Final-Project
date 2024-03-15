using BMW_Final_Project.Core.Contracts;
using BMW_Final_Project.Core.Models;
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
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var modelToAdd = new AddMotorcycleModel()
            {
                TypeMotorModels = await _service.GetTypeMotorcyclesAsync(),
                ColorCategoryModels = await _service.GetColorsAsync(),
                StandardEuroModels = await _service.GetStandardEurosAsync()
            };

            return View(modelToAdd);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddMotorcycleModel modelToAdd)
        {
            if (!ModelState.IsValid)
            {
                modelToAdd.TypeMotorModels = await _service.GetTypeMotorcyclesAsync();
                modelToAdd.ColorCategoryModels = await _service.GetColorsAsync();
                modelToAdd.StandardEuroModels = await _service.GetStandardEurosAsync();

                return View(modelToAdd);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
