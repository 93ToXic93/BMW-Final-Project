using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;
using BMW_Final_Project.Infrastructure.Constants;
using Microsoft.AspNetCore.Identity;

namespace BMW_Final_Project.Infrastructure.Data.IdentityModels
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        [MaxLength(DataConstants.ApplicationUserConstants.FirstNameMaxLength)]
        public string? FirstName { get; set; } = string.Empty;

        [MaxLength(DataConstants.ApplicationUserConstants.LastNameMaxLength)]
        public string? LastName { get; set; } = string.Empty;

        [MaxLength(DataConstants.ApplicationUserConstants.NicknameMaxLength)] 
        public string? Nickname { get; set; } = string.Empty;
    }
}
