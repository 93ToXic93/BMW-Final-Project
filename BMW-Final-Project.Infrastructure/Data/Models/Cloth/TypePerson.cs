using System.ComponentModel.DataAnnotations;
using BMW_Final_Project.Infrastructure.Constants;
using Microsoft.EntityFrameworkCore;

namespace BMW_Final_Project.Infrastructure.Data.Models.Cloth
{
    [Comment("TypePerson's table")]
    public class TypePerson
    {
        [Comment("TypePerson identifier")]
        [Key]
        public int Id { get; set; }

        [Comment("TypePerson type")]
        [Required]
        [MaxLength(DataConstants.TypePersonConstants.NameMaxLength)]
        public string Name { get; set; } = string.Empty;

        public ICollection<Cloth> Cloths { get; set; } = new List<Cloth>();
    }
}