using System.Security.Claims;

namespace BMW_Final_Project.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static Guid Id(this ClaimsPrincipal user)
        {
            return Guid.Parse(user.FindFirstValue(ClaimTypes.NameIdentifier));
        }
    }
}
