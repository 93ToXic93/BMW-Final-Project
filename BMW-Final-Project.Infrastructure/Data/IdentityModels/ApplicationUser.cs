using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;
using Microsoft.AspNetCore.Identity;

namespace BMW_Final_Project.Infrastructure.Data.IdentityModels
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        [MaxLength(50)]
        public string? FirstName { get; set; } = string.Empty;

        [MaxLength(50)]
        public string? LastName { get; set; } = string.Empty;

        [MaxLength(50)] 
        public string? Nickname { get; set; } = string.Empty;
    }
}
