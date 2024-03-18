using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BMW_Final_Project.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        public bool IsAuthorized()
        {
            return User.Identity.IsAuthenticated && User.IsInRole("Admin");
        }

        public string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
