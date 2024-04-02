using BMW_Final_Project.Engine.Contracts;
using BMW_Final_Project.Engine.Models.Cloth;
using BMW_Final_Project.Engine.Models.Motorcycle;
using BMW_Final_Project.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BMW_Final_Project.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : BaseController
    {

        private readonly IMotorcycleService _motorcycleService;
        private readonly IClothService _clothService;

        public AdminController(IMotorcycleService motorcycleService,IClothService clothService)
        {
            _motorcycleService = motorcycleService;
            _clothService = clothService;
        }

        [HttpGet]
        public async Task<IActionResult> AddMotorcycle()
        {

            var modelToAdd = new AddMotorcycleModel()
            {
                TypeMotorModels = await _motorcycleService.GetTypeMotorcyclesAsync(),
                StandardEuroModels = await _motorcycleService.GetStandardEurosAsync()
            };

            return View(modelToAdd);
        }

        [HttpPost]
        public async Task<IActionResult> AddMotorcycle(AddMotorcycleModel modelToAdd)
        {

            if (await _motorcycleService.IsThisMotorcycleExistAsync(modelToAdd))
            {
                ModelState.AddModelError(string.Empty, "Този мотор вече съществува!");
            }

            if (!ModelState.IsValid)
            {
                modelToAdd.TypeMotorModels = await _motorcycleService.GetTypeMotorcyclesAsync();
                modelToAdd.StandardEuroModels = await _motorcycleService.GetStandardEurosAsync();

                return View(modelToAdd);
            }

            modelToAdd.BuyerId = User.Id();

            await _motorcycleService.AddAsync(modelToAdd);

            return RedirectToAction("Index", "Motorcycle");
        }

        [HttpGet]
        public async Task<IActionResult> EditMotorcycle(int id)
        {
            try
            {
                var model = await _motorcycleService.GetByIdAsync(id);

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
                    StandardEuroId = model.StandardEuroId,
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
                modelToEdit.StandardEuroModels = await _motorcycleService.GetStandardEurosAsync();
                modelToEdit.TypeMotorModels = await _motorcycleService.GetTypeMotorcyclesAsync();
                return View(modelToEdit);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status403Forbidden);
            }

        }

        [HttpPost]
        public async Task<IActionResult> EditMotorcycle(EditMotorcycleModel modelToEdit, int id)
        {

            if (!ModelState.IsValid)
            {
                modelToEdit.TypeMotorModels = await _motorcycleService.GetTypeMotorcyclesAsync();
                modelToEdit.StandardEuroModels = await _motorcycleService.GetStandardEurosAsync();

                return View(modelToEdit);
            }

            try
            {
                await _motorcycleService.EditAsync(modelToEdit);
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
                await _motorcycleService.DeleteAsync(id);
            }
            catch (Exception e)
            {
                return BadRequest();
            }

            return RedirectToAction("Index", "Motorcycle");
        }


        [HttpPost]
        public async Task<IActionResult> AddColor(AddColorModel model)
        {

            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(AddMotorcycle));
            }

            try
            {
                await _motorcycleService.AddNewColorAsync(model);
            }
            catch (Exception e)
            {
                return RedirectToAction(nameof(AddMotorcycle));
            }



            return RedirectToAction(nameof(AddMotorcycle));
        }

        [HttpGet]
        public async Task<IActionResult> GetColors()
        {
            try
            {
                var colors = await _motorcycleService.GetColorsAsync();
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
                var colorsModel = await _motorcycleService.GetColorsToDeleteAsync(currentPage, colorsPerPage);

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
                await _motorcycleService.DeleteColorAsync(id);

                return RedirectToAction(nameof(ShowColorToDelete));
            }
            catch (Exception e)
            {
                return BadRequest();
            }

        }



        [HttpGet]
        public async Task<IActionResult> AddCloth()
        {

            var modelToAdd = new AddClothModel()
            {
                SizeModels = await _clothService.GetSizesAsync(),
                TypePersonModels = await _clothService.GetTypesAsync(),
                ClothCollectionModels = await _clothService.GetClothCollectionsAsync()
            };

            return View(modelToAdd);
        }

        [HttpPost]
        public async Task<IActionResult> AddCloth(AddClothModel modelToAdd)
        {

            if (await _clothService.IsThisClothExistAsync(modelToAdd))
            {
                ModelState.AddModelError(string.Empty, "Този мотор вече съществува!");
            }

            if (!ModelState.IsValid)
            {
                modelToAdd.SizeModels = await _clothService.GetSizesAsync();
                modelToAdd.TypePersonModels = await _clothService.GetTypesAsync();
                modelToAdd.ClothCollectionModels = await _clothService.GetClothCollectionsAsync();

                return View(modelToAdd);
            }

            modelToAdd.BuyerId = User.Id();

            await _clothService.AddAsync(modelToAdd);

            return RedirectToAction("Index", "Cloth");
        }

        [HttpGet]
        public async Task<IActionResult> EditCloth(int id)
        {
            try
            {
                var model = await _clothService.GetByIdAsync(id);

                if (model == null)
                {
                    return BadRequest();
                }

                if (id != model.Id)
                {
                    return BadRequest();
                }
                var modelToEdit = new EditClothModel
                {
                    Amount = model.Amount,
                    ImgUrl = model.ImgUrl,
                    Price = model.Price,
                    ClothCollectionId = model.ClothCollectionId,
                    Description = model.Description,
                    Name = model.Name,
                    Id = model.Id,
                    SizeId = model.SizeId,
                    TypePersonId = model.TypePersonId,
                    ClothCollectionModels = await _clothService.GetClothCollectionsAsync(),
                    SizeModels = await _clothService.GetSizesAsync(),
                    TypePersonModels = await _clothService.GetTypesAsync()
                };
                return View(modelToEdit);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status403Forbidden);
            }

        }

        [HttpPost]
        public async Task<IActionResult> EditCloth(EditClothModel modelToEdit, int id)
        {

            if (!ModelState.IsValid)
            {
                modelToEdit.ClothCollectionModels = await _clothService.GetClothCollectionsAsync();
                modelToEdit.SizeModels = await _clothService.GetSizesAsync();
                modelToEdit.TypePersonModels = await _clothService.GetTypesAsync();

                return View(modelToEdit);
            }

            try
            {
                await _clothService.EditAsync(modelToEdit);
            }
            catch (Exception e)
            {
                return BadRequest();
            }



            return RedirectToAction("Index", "Cloth");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCloth(int id)
        {

            try
            {
                await _clothService.DeleteAsync(id);
            }
            catch (Exception e)
            {
                return BadRequest();
            }

            return RedirectToAction("Index", "Cloth");
        }

    }
}
