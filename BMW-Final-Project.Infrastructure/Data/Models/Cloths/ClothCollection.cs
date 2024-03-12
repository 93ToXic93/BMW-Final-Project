using System.ComponentModel.DataAnnotations;
using BMW_Final_Project.Infrastructure.Constants;
using Microsoft.EntityFrameworkCore;

namespace BMW_Final_Project.Infrastructure.Data.Models.Cloths
{
    [Comment("Season cloth collections")]
    public class ClothCollection
    {
        [Comment("Collection identifier")]
        [Key]
        public int Id { get; set; }

        [Comment("Collection Name")]
        [Required]
        [MaxLength(DataConstants.ClothCollectionConstants.NameMaxLength)]
        public string Name { get; set; } = string.Empty;

        public ICollection<Cloth> Cloths { get; set; } = new List<Cloth>();
    }
}
