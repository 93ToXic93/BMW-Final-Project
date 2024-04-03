using BMW_Final_Project.Infrastructure.Data.IdentityModels;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BMW_Final_Project.Infrastructure.Data.Models.Motorcycle
{
    [Comment("Motorcycles and buyers")]
    public class MotorcycleBuyers
    {
        [Required]
        [Comment("Motorcycle identifier")]
        public int MotorcycleId { get; set; }

        [ForeignKey(nameof(MotorcycleId))]
        public Motorcycle Motorcycle { get; set; } = null!;

        [Required]
        [Comment("Buyer identifier")]
        public Guid BuyerId { get; set; }

        [ForeignKey(nameof(BuyerId))]
        public ApplicationUser Buyer { get; set; } = null!;
    }
}