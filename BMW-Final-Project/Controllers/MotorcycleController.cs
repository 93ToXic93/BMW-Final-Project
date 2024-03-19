using BMW_Final_Project.Engine.Contracts;
using BMW_Final_Project.Engine.Models.Motorcycle;
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

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            if (!IsAuthorized())
            {
                return Unauthorized();
            }

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
            if (!IsAuthorized())
            {
                return Unauthorized();
            }

            if (!ModelState.IsValid)
            {
                modelToAdd.TypeMotorModels = await _service.GetTypeMotorcyclesAsync();
                modelToAdd.ColorCategoryModels = await _service.GetColorsAsync();
                modelToAdd.StandardEuroModels = await _service.GetStandardEurosAsync();

                return View(modelToAdd);
            }

            modelToAdd.BuyerId = GetUserId();

            await _service.AddAsync(modelToAdd);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _service.GetByIdAsync(id);

            if (!IsAuthorized())
            {
                return Unauthorized();
            }

            if (model == null)
            {
                return BadRequest();
            }

            if (id != model.Id)
            {
                return BadRequest();
            }

            var modelToEdit = new EditMotorcycleModel
            {
                Amount = model.Amount,
                ImageUrl = model.ImageUrl,
                Model = model.Model,
                CC = model.CC,
                DTC = model.DTC,
                FrontBreak = model.FrontBreak,
                RearBreak = model.RearBreak,
                TankCapacity = model.TankCapacity,
                TypeMotorId = model.TypeMotorId,
                Transmission = model.Transmission,
                Kg = model.Kg,
                Price = model.Price,
                SeatHeightMm = model.SeatHeightMm,
                HorsePowers = model.HorsePowers,
                Year = model.Year,
                ColorCategoryModels = await _service.GetColorsAsync(),
                StandardEuroModels = await _service.GetStandardEurosAsync(),
                TypeMotorModels = await _service.GetTypeMotorcyclesAsync()
            };

            return View(modelToEdit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditMotorcycleModel modelToEdit, int id)
        {
            if (!IsAuthorized())
            {
                return Unauthorized();
            }

            if (!ModelState.IsValid)
            {
                modelToEdit.TypeMotorModels = await _service.GetTypeMotorcyclesAsync();
                modelToEdit.ColorCategoryModels = await _service.GetColorsAsync();
                modelToEdit.StandardEuroModels = await _service.GetStandardEurosAsync();

                return View(modelToEdit);
            }

            try
            {
                await _service.EditAsync(modelToEdit);
            }
            catch (Exception e)
            {
                return BadRequest();
            }



            return RedirectToAction(nameof(Index));
        }

    }
}
