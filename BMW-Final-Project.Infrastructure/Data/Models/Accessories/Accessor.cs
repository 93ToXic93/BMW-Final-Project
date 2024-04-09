using BMW_Final_Project.Infrastructure.Data.IdentityModels;
using BMW_Final_Project.Infrastructure.Data.Models.Cloth;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static BMW_Final_Project.Infrastructure.Constants.DataConstants.AccessorConstants;

namespace BMW_Final_Project.Infrastructure.Data.Models.Accessories
{
    [Comment("Accessories table")]
    public class Accessor
    {
        [Key]
        [Comment("Accessor identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("Accessor's name")]
        [MaxLength(MaxNameLength)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Range(MinPrice,MaxPrice)]
        [Comment("Accessor's price")]
        public decimal Price { get; set; }

        [Required]
        [Comment("Accessor's type")]
        public int ItemTypeId { get; set; }

        [ForeignKey(nameof(ItemTypeId))]
        public ItemType ItemType { get; set; } = null!;

        [Required]
        [Comment("Buyer identifier")]
        public Guid BuyerId { get; set; }

        [ForeignKey(nameof(BuyerId))]
        public ApplicationUser Buyer { get; set; } = null!;

        [Required]
        [Comment("Accessor's state")]
        public bool IsActive { get; set; }

        [Required]
        [MaxLength(UrlMaxLength)]
        [Comment("Accessor's image")]
        public string ImgUrl { get; set; } = string.Empty;

        [Range(MinAmount,MaxAmount)]
        [Required]
        public int Amount { get; set; }

        public ICollection<AccessorBuyer> AccessorBuyers { get; set; } = new List<AccessorBuyer>();

    }
}
