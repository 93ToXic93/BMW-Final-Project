using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BMW_Final_Project.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {

    }
}
