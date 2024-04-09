using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace BMW_Final_Project.Infrastructure.Data.Models.Accessories
{
    [Comment("Accessories table")]
    public class Accessor
    {
        [Key]
        [Comment("Accessor identifier")]
        public int Id { get; set; }

        [Comment("Accessor's name")]
        [MaxLength()]
        public string Name { get; set; } = string.Empty;
    }
}
