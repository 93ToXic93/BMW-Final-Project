using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BMW_Final_Project.Infrastructure.Data.Models.Cloths
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
        public string BuyerId { get; set; } = string.Empty;

        [ForeignKey(nameof(BuyerId))]
        public IdentityUser Buyer { get; set; } = null!;
    }
}
