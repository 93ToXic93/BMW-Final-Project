using BMW_Final_Project.Engine.Contracts;
using BMW_Final_Project.Engine.Models.Motorcycle;
using BMW_Final_Project.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace BMW_Final_Project.Controllers
{
    public class AdminController : BaseController
    {

        private readonly IMotorcycleService _service;

        public AdminController(IMotorcycleService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> AddMotorcycle()
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
        public async Task<IActionResult> AddMotorcycle(AddMotorcycleModel modelToAdd)
        {
            if (!IsAuthorized())
            {
                return Unauthorized();
            }

            if (await _service.IsThisMotorcycleExistAsync(modelToAdd))
            {
                ModelState.AddModelError(string.Empty, "Този мотор вече съществува!");
            }

            if (!ModelState.IsValid)
            {
                modelToAdd.TypeMotorModels = await _service.GetTypeMotorcyclesAsync();
                //modelToAdd.ColorCategoryModels = await _service.GetColorsAsync();
                modelToAdd.StandardEuroModels = await _service.GetStandardEurosAsync();

                return View(modelToAdd);
            }

            modelToAdd.BuyerId = User.Id();

            await _service.AddAsync(modelToAdd);

            return RedirectToAction("Index", "Motorcycle");
        }

        [HttpGet]
        public async Task<IActionResult> EditMotorcycle(int id)
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
            };
            //modelToEdit.ColorCategoryModels = await _service.GetColorsAsync();
            modelToEdit.StandardEuroModels = await _service.GetStandardEurosAsync();
            modelToEdit.TypeMotorModels = await _service.GetTypeMotorcyclesAsync();

            return View(modelToEdit);
        }

        [HttpPost]
        public async Task<IActionResult> EditMotorcycle(EditMotorcycleModel modelToEdit, int id)
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



            return RedirectToAction("Index", "Motorcycle");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteMotorcycle(int id)
        {
            if (!IsAuthorized())
            {
                return Unauthorized();
            }

            try
            {
                await _service.DeleteAsync(id);
            }
            catch (Exception e)
            {
                return BadRequest();
            }

            return RedirectToAction("Index", "Motorcycle");
        }


        [HttpPost]
        public async Task<IActionResult> AddColor([FromBody] AddColorModel model)
        {
            if (!IsAuthorized())
            {
                return Unauthorized();
            }

            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(AddMotorcycle));
            }

            try
            {
                await _service.AddNewColorAsync(model);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }



            return RedirectToAction(nameof(AddMotorcycle));
        }

        [HttpGet]
        public async Task<IActionResult> GetColors()
        {
            var colors = await _service.GetColorsAsync();


            return Json(colors); 
        }

        [HttpGet]
        public async Task<IActionResult> ShowColorToDelete(int currentPage = 1, int colorsPerPage = 10)
        {
            if (!IsAuthorized())
            {
                return BadRequest();
            }
            var colorsModel = await _service.GetColorsToDeleteAsync(currentPage, colorsPerPage);

            return View(colorsModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteColor(int id)
        {
            if (!IsAuthorized())
            {
                return BadRequest();
            }

            await _service.DeleteColorAsync(id);

            return RedirectToAction(nameof(ShowColorToDelete));
        }
    }
}
