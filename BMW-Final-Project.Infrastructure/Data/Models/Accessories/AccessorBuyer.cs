using BMW_Final_Project.Infrastructure.Data.IdentityModels;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BMW_Final_Project.Infrastructure.Data.Models.Accessories
{
    [Comment("Accessors and buyers table")]
    public class AccessorBuyer
    {
        [Required]
        [Comment("Accessor identifier")]
        public int AccessorId { get; set; }

        [ForeignKey(nameof(AccessorId))]
        public Accessor Accessor { get; set; } = null!;

        [Required]
        [Comment("Buyer identifier")]
        public Guid BuyerId { get; set; }

        [ForeignKey(nameof(BuyerId))]
        public ApplicationUser Buyer { get; set; } = null!;
    }
}
