using BMW_Final_Project.Engine.Contracts;
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
    }
}
