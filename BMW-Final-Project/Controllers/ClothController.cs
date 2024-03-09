using Microsoft.AspNetCore.Mvc;

namespace BMW_Final_Project.Controllers
{
    public class ClothController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
