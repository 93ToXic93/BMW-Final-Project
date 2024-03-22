using System.ComponentModel.DataAnnotations;
using BMW_Final_Project.Infrastructure.Constants;
using static BMW_Final_Project.Infrastructure.Constants.DataConstants.CategoryColorConstants;

namespace BMW_Final_Project.Engine.Models.Motorcycle
{
    public class AddColorModel
    {
        public int Id { get; set; }

        [StringLength(MaxColorNameLength, MinimumLength = MinColorNameLength, ErrorMessage = DataConstants.LengthErrorMessage)]
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public bool IsActive { get; set; }
    }
}
