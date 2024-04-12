using BMW_Final_Project.Engine.Contracts;
using BMW_Final_Project.Extensions;
using BMW_Final_Project.Infrastructure.Constants;
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

        [HttpGet]
        public async Task<IActionResult> AllBought()
        {
            var accsesoaries = await _accessoriesService.GetAllMineAccsesoariesAsync(User.Id());

            return View(accsesoaries);
        }

        [HttpPost]
        public async Task<IActionResult> BuyAccsesoar(int id)
        {
            try
            {
                await _accessoriesService.AddAsync(id, User.Id());

                TempData[DataConstants.UserMessageSuccess] = "Успешно добавихте в количката този аксесоар!";

                return RedirectToAction(nameof(AllBought));
            }
            catch (Exception e)
            {
                TempData[DataConstants.UserMessageError] = "Този аксесоар вече е добавен в количката!";

                return RedirectToAction(nameof(Index));
            }

        }

        [HttpPost]
        public async Task<IActionResult> RemoveAccsesoar(int id)
        {
            try
            {
                await _accessoriesService.RemoveAccsesoarAsync(id);

                TempData[DataConstants.UserMessageSuccess] = "Успешно премахнахте от количката този аксесоар!";


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
                await _accessoriesService.BuyAccsesoarAsync(id);

                TempData[DataConstants.UserMessageSuccess] = "Успешно закупихте този аксесоар!";


                return RedirectToAction(nameof(AllBought));
            }
            catch (Exception e)
            {
                return NotFound();
            }

        }
    }
}
