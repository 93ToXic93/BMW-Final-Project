using BMW_Final_Project.Infrastructure.Data.IdentityModels;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static BMW_Final_Project.Infrastructure.Constants.DataConstants.ClothConstants;

namespace BMW_Final_Project.Infrastructure.Data.Models.Cloths
{
    [Comment("Cloth table")]
    public class Cloth
    {
        [Comment("Cloth identifier")]
        [Key]
        public int Id { get; set; }

        [Comment("Cloth name")]
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = string.Empty;

        [Comment("Cloth description")]
        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = string.Empty;

        [Comment("Cloth image")]
        [Required]
        [MaxLength(ImgUrlMaxLength)]
        public string ImgUrl { get; set; } = string.Empty;

        [Comment("Cloth price")]
        [Required]
        [Range(PriceMin, PriceMax)]
        public decimal Price { get; set; }

        [Required]
        [Comment("Cloth status")]
        public bool IsActive { get; set; }

        [Required]
        [Comment("Cloth amount")]
        [Range(AmountMin, AmountMax)]
        public int Amount { get; set; }

        [Required]
        [Comment("Cloth collection identifier")]
        public int ClothCollectionId { get; set; }

        [ForeignKey(nameof(ClothCollectionId))]
        public ClothCollection ClothCollection { get; set; } = null!;

        [Required]
        [Comment("Size identifier")]
        public int SizeId { get; set; }

        [ForeignKey(nameof(SizeId))]
        public Size Size { get; set; } = null!;

        [Required]
        [Comment("TypePerson identifier")]
        public int TypePersonId { get; set; }

        [ForeignKey(nameof(TypePersonId))]
        public TypePerson TypePerson { get; set; } = null!;

        [Required]
        [Comment("Buyer identifier")]
        public Guid BuyerId { get; set; } 

        [ForeignKey(nameof(BuyerId))]
        public ApplicationUser Buyer { get; set; } = null!;

        public ICollection<ClothBuyer> ClothBuyers { get; set; } = new List<ClothBuyer>();

    }
}
