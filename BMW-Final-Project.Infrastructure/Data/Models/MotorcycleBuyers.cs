using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BMW_Final_Project.Infrastructure.Data.Models
{
    [Comment("Motorcycles and Buyers")]
    public class MotorcycleBuyers
    {
        [Required]
        [Comment("Motorcycle identifier")]
        public int MotorcycleId { get; set; }

        [ForeignKey(nameof(MotorcycleId))]
        public Motorcycle Motorcycle { get; set; } = null!;

        [Required]
        [Comment("Buyer identifier")]
        public string BuyerId { get; set; } = string.Empty;

        [ForeignKey(nameof(BuyerId))]
        public IdentityUser Buyer { get; set; } = null!;
    }
}
