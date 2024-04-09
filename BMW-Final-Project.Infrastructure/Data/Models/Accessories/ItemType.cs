using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static BMW_Final_Project.Infrastructure.Constants.DataConstants.ItemTypeConstants;

namespace BMW_Final_Project.Infrastructure.Data.Models.Accessories
{
    [Comment("Item's type table")]
    public class ItemType
    {
        [Comment("ItemType identifier")]
        [Key]
        public int Id { get; set; }

        [Comment("Item type Name")]
        [MaxLength(MaxNameLength)]
        [Required]
        public string Name { get; set; } = string.Empty;

        public ICollection<Accessor> Accessories { get; set; } = new List<Accessor>();
    }
}
