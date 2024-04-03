using BMW_Final_Project.Infrastructure.Constants;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BMW_Final_Project.Infrastructure.Data.Models.Motorcycle
{
    [Comment("Type of the motorcycle")]
    public class TypeMotor
    {
        [Key]
        [Comment("Type identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("Type name")]
        [MaxLength(DataConstants.TypeMotorConstants.MaxTypeNameLength)]
        public string Name { get; set; } = string.Empty;

        public ICollection<Motorcycle> Motorcycles { get; set; } = new List<Motorcycle>();
    }
}