using BMW_Final_Project.Infrastructure.Constants;
using System.ComponentModel.DataAnnotations;

namespace BMW_Final_Project.Engine.Models.Motorcycle
{
    public class ColorCategoryModel
    {
        public int Id { get; set; }

        [StringLength(DataConstants.CategoryColorConstants.MaxColorNameLength, MinimumLength = DataConstants.CategoryColorConstants.MinColorNameLength, ErrorMessage = DataConstants.LengthErrorMessage)]
        [Required(ErrorMessage = DataConstants.RequiredErrorMessage)]
        public string Name { get; set; } = string.Empty;

        public bool IsActive { get; set; }
    }
}