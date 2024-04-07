using BMW_Final_Project.Engine.Contracts;
using BMW_Final_Project.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace BMW_Final_Project.Controllers
{
    public class EventController : BaseController
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await _eventService.GetAllEvents();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AllJoined()
        {
            var events = await _eventService.GetAllMineEventsAsync(User.Id());

            return View(events);
        }

        [HttpPost]
        public async Task<IActionResult> JoinEvent(int id)
        {
            try
            {
                await _eventService.AddAsync(id, User.Id());
                return RedirectToAction(nameof(AllJoined));
            }
            catch (Exception e)
            {
                return RedirectToAction(nameof(Index));
            }

        }

        [HttpPost]
        public async Task<IActionResult> RemoveEvent(int id)
        {
            try
            {
                var userId = User.Id();

                await _eventService.RemoveEventAsync(id, userId);
                return RedirectToAction(nameof(AllJoined));
            }
            catch (Exception e)
            {
                return NotFound();
            }

        }

    }
}
