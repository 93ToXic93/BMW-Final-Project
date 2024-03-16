using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static BMW_Final_Project.Infrastructure.Constants.DataConstants.StandardEuroConstants;
namespace BMW_Final_Project.Infrastructure.Data.Models.Motorcycles
{
    [Comment("Euro standard table")]
    public class StandardEuro
    {
        [Key]
        [Comment("Euro standard identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxStandardNameLength)]
        [Comment("Standard euro category")]
        public string Name { get; set; } = string.Empty;

        public ICollection<Motorcycle> Motorcycles { get; set; } = new List<Motorcycle>();

    }
}