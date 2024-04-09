using BMW_Final_Project.Engine.Contracts;
using BMW_Final_Project.Engine.Models.Accessories;
using BMW_Final_Project.Engine.Models.Cloth;
using BMW_Final_Project.Engine.Models.Event;
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
        private readonly IEventService _eventService;
        private readonly IAccessoriesService _accessoriesService;

        public AdminController(IMotorcycleService motorcycleService,
            IClothService clothService,
            IEventService eventService,
            IAccessoriesService accessoriesService)
        {
            _motorcycleService = motorcycleService;
            _clothService = clothService;
            _eventService = eventService;
            _accessoriesService = accessoriesService;
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
                    ColorCategoryId = model.ColorCategoryId
                };
                modelToEdit.StandardEuroModels = await _motorcycleService.GetStandardEurosAsync();
                modelToEdit.TypeMotorModels = await _motorcycleService.GetTypeMotorcyclesAsync();
                modelToEdit.ColorCategoryModels = await _motorcycleService.GetColorsAsync();
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

            var motorcycleToEdit = await _motorcycleService.GetByIdAsync(modelToEdit.Id);

            if (motorcycleToEdit == null)
            {
                return NotFound();
            }

            if (motorcycleToEdit.Model != modelToEdit.Model)
            {
                if (await _motorcycleService.IsThisMotorcycleExistEditAsync(modelToEdit))
                {
                    ModelState.AddModelError(string.Empty, "Този мотор вече съществува!");
                }
            }


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

            var eventEdited = await _clothService.GetByIdAsync(modelToEdit.Id);

            if (eventEdited == null)
            {
                return NotFound();
            }

            if (eventEdited.Name != modelToEdit.Name)
            {
                if (await _clothService.IsThisClothExistWhenEditAsync(modelToEdit))
                {
                    ModelState.AddModelError(string.Empty, "Това облекло вече съществува!");
                }
            }

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



        [HttpPost]
        public async Task<IActionResult> DeleteEvent(int id)
        {

            try
            {
                await _eventService.DeleteAsync(id);
            }
            catch (Exception e)
            {
                return BadRequest();
            }

            return RedirectToAction("Index", "Event");
        }

        [HttpGet]
        public IActionResult AddEvent()
        {

            var eventToAdd = new AddEventModel();

            return View(eventToAdd);
        }

        [HttpPost]
        public async Task<IActionResult> AddEvent(AddEventModel eventToAdd)
        {

            if (await _eventService.IsThisEventExistAsync(eventToAdd))
            {
                ModelState.AddModelError(string.Empty, "Това събитие вече съществува!");
            }

            if (!(await _eventService.IsTheDatesAreCorrectAsync(eventToAdd.StartEvent, eventToAdd.EndEvent)))
            {
                ModelState.AddModelError(string.Empty, "Датата е невалидна, трябва да имат поне час разлика и започващата дата да не е преди завършващата!");
            }

            if (!ModelState.IsValid)
            {
                return View(eventToAdd);
            }

            eventToAdd.JoinerId = User.Id();

            await _eventService.AddAsync(eventToAdd);

            return RedirectToAction("Index", "Event");
        }

        [HttpGet]
        public async Task<IActionResult> EditEvent(int id)
        {
            try
            {
                var model = await _eventService.GetByIdAsync(id);

                if (model == null)
                {
                    return BadRequest();
                }

                if (id != model.Id)
                {
                    return BadRequest();
                }
                var modelToEdit = new EditEventModel
                {
                    Id = model.Id,
                    Description = model.Description,
                    EndEvent = model.EndEvent,
                    StartEvent = model.StartEvent,
                    ImgUrl = model.ImgUrl,
                    Name = model.Name,
                    PlaceOfTheEvent = model.PlaceOfTheEvent

                };
                return View(modelToEdit);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status403Forbidden);
            }

        }

        [HttpPost]
        public async Task<IActionResult> EditEvent(EditEventModel modelToEdit, int id)
        {

            var eventEdited = await _eventService.GetByIdAsync(modelToEdit.Id);

            if (eventEdited == null)
            {
                return NotFound();
            }

            if (eventEdited.Name != modelToEdit.Name)
            {
                if (await _eventService.IsThisEventExistWhenEditAsync(modelToEdit))
                {
                    ModelState.AddModelError(string.Empty, "Това събитие вече съществува!");
                }
            }

            if (!ModelState.IsValid)
            {
                return View(modelToEdit);
            }

            try
            {
                await _eventService.EditAsync(modelToEdit);
            }
            catch (Exception e)
            {
                return BadRequest();
            }



            return RedirectToAction("Index", "Event");
        }

        [HttpGet]
        public async Task<IActionResult> AllJoinedUsersForEvent(int id, int currentPage = 1, int joinersPerPage = 10)
        {
            try
            {
                var model = await _eventService.AllJoinedUsersForEventAsync(id, currentPage, joinersPerPage);

                return View(model);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }


        [HttpGet]
        public async Task<IActionResult> AddAccessoar()
        {

            var accsModel = new AddAccsessoarModel();

            accsModel.ItemTypeModel = await _accessoriesService.GetItemTypeModelAsync();

            return View(accsModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddAccessoar(AddAccsessoarModel accsModel)
        {

            if (await _accessoriesService.IsThisAccsesoarExistAsync(accsModel))
            {
                ModelState.AddModelError(string.Empty, "Този аксесоар вече съществува!");
            }


            if (!ModelState.IsValid)
            {
                accsModel.ItemTypeModel = await _accessoriesService.GetItemTypeModelAsync();

                return View(accsModel);
            }

            accsModel.BuyerId = User.Id();

            await _accessoriesService.AddAsync(accsModel);

            return RedirectToAction("Index", "Accessories");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAccsesoar(int id)
        {

            try
            {
                await _accessoriesService.DeleteAsync(id);
            }
            catch (Exception e)
            {
                return BadRequest();
            }

            return RedirectToAction("Index", "Accessories");
        }

        [HttpGet]
        public async Task<IActionResult> EditAccsesoar(int id)
        {
            try
            {
                var model = await _accessoriesService.GetByIdAsync(id);

                if (model == null)
                {
                    return BadRequest();
                }

                if (id != model.Id)
                {
                    return BadRequest();
                }
                var modelToEdit = new EditAccsesoarModel
                {
                    Id = model.Id,
                    ImgUrl = model.ImgUrl,
                    Name = model.Name,
                    Price = model.Price,
                    Amount = model.Amount,
                    ItemTypeId = model.ItemTypeId,

                };

                modelToEdit.ItemTypeModel = await _accessoriesService.GetItemTypeModelAsync();

                return View(modelToEdit);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status403Forbidden);
            }

        }

        [HttpPost]
        public async Task<IActionResult> EditAccsesoar(EditAccsesoarModel modelToEdit, int id)
        {

            var eventEdited = await _accessoriesService.GetByIdAsync(modelToEdit.Id);

            if (eventEdited == null)
            {
                return NotFound();
            }

            if (eventEdited.Name != modelToEdit.Name)
            {
                if (await _accessoriesService.IsThisAccsesoarExistWhenEditAsync(modelToEdit))
                {
                    ModelState.AddModelError(string.Empty, "Това събитие вече съществува!");
                }
            }

            if (!ModelState.IsValid)
            {
                modelToEdit.ItemTypeModel = await _accessoriesService.GetItemTypeModelAsync();
                return View(modelToEdit);
            }

            try
            {
                await _accessoriesService.EditAsync(modelToEdit);
            }
            catch (Exception e)
            {
                return BadRequest();
            }



            return RedirectToAction("Index", "Accessories");
        }
    }
}
