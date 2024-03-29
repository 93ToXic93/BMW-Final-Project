using BMW_Final_Project.Engine.Contracts;
using BMW_Final_Project.Engine.Models.Motorcycle;
using BMW_Final_Project.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BMW_Final_Project.Controllers
{
    [Authorize(Roles = "Admin")]
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

            var modelToAdd = new AddMotorcycleModel()
            {
                TypeMotorModels = await _service.GetTypeMotorcyclesAsync(),
                StandardEuroModels = await _service.GetStandardEurosAsync()
            };

            return View(modelToAdd);
        }

        [HttpPost]
        public async Task<IActionResult> AddMotorcycle(AddMotorcycleModel modelToAdd)
        {

            if (await _service.IsThisMotorcycleExistAsync(modelToAdd))
            {
                ModelState.AddModelError(string.Empty, "Този мотор вече съществува!");
            }

            if (!ModelState.IsValid)
            {
                modelToAdd.TypeMotorModels = await _service.GetTypeMotorcyclesAsync();
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
            try
            {
                var model = await _service.GetByIdAsync(id);

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
                modelToEdit.StandardEuroModels = await _service.GetStandardEurosAsync();
                modelToEdit.TypeMotorModels = await _service.GetTypeMotorcyclesAsync();
                return View(modelToEdit);
            }
            catch (Exception e)
            {
                return Unauthorized();
            }

        }

        [HttpPost]
        public async Task<IActionResult> EditMotorcycle(EditMotorcycleModel modelToEdit, int id)
        {

            if (!ModelState.IsValid)
            {
                modelToEdit.TypeMotorModels = await _service.GetTypeMotorcyclesAsync();
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
                return BadRequest();
            }



            return RedirectToAction(nameof(AddMotorcycle));
        }

        [HttpGet]
        public async Task<IActionResult> GetColors()
        {
            try
            {
                var colors = await _service.GetColorsAsync();
                return Json(colors);
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }

        [HttpGet]
        public async Task<IActionResult> ShowColorToDelete(int currentPage = 1, int colorsPerPage = 10)
        {

            try
            {
                var colorsModel = await _service.GetColorsToDeleteAsync(currentPage, colorsPerPage);

                return View(colorsModel);
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteColor(int id)
        {
            try
            {
                await _service.DeleteColorAsync(id);

                return RedirectToAction(nameof(ShowColorToDelete));
            }
            catch (Exception e)
            {
                return BadRequest();
            }

        }

    }
}
