using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using static BMW_Final_Project.Infrastructure.Constants.DataConstants.CategoryColorConstants;

namespace BMW_Final_Project.Infrastructure.Data.Models.Motorcycles
{
    [Comment("Color Table")]
    public class ColorCategory
    {
        [Key]
        [Comment("Color identifier")]
        public int Id { get; set; }

        [MaxLength(MaxColorNameLength)]
        [Required]
        [Comment("Color Name")]
        public string Name { get; set; } = string.Empty;

        [Comment("Color ad status")]
        [Required]
        public bool IsActive { get; set; }

        public ICollection<Motorcycle> Motorcycles { get; set; } = new List<Motorcycle>();
    }
}