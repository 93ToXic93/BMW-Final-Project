using BMW_Final_Project.Infrastructure.Data.IdentityModels;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BMW_Final_Project.Infrastructure.Data.Models.Cloth
{
    [Comment("Cloth and buyers")]
    public class ClothBuyer
    {
        [Required]
        [Comment("Cloth identifier")]
        public int ClothId { get; set; }

        [ForeignKey(nameof(ClothId))]
        public Cloth Cloth { get; set; } = null!;

        [Required]
        [Comment("Buyer identifier")]
        public Guid BuyerId { get; set; } 

        [ForeignKey(nameof(BuyerId))]
        public ApplicationUser Buyer { get; set; } = null!;
    }
}