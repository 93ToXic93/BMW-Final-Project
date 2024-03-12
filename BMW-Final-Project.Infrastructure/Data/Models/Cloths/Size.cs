using System.ComponentModel.DataAnnotations;
using BMW_Final_Project.Infrastructure.Constants;
using Microsoft.EntityFrameworkCore;

namespace BMW_Final_Project.Infrastructure.Data.Models.Cloths
{
    [Comment("Size table")]
    public class Size
    {
        [Comment("Size identifier")]
        [Key]
        public int Id { get; set; }

        [Comment("Size")]
        [Required]
        [MaxLength(DataConstants.SizeConstants.NameMaxLength)]
        public string Name { get; set; } = string.Empty;

        public ICollection<Cloth> Cloths { get; set; } = new List<Cloth>();
    }
}
