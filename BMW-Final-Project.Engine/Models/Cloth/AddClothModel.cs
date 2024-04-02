using BMW_Final_Project.Infrastructure.Constants;
using System.ComponentModel.DataAnnotations;
using static BMW_Final_Project.Infrastructure.Constants.DataConstants.ClothConstants;

namespace BMW_Final_Project.Engine.Models.Cloth
{
    public class AddClothModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = DataConstants.RequiredErrorMessage)]
        [StringLength(NameMaxLength,MinimumLength = NameMinLength,ErrorMessage = DataConstants.LengthErrorMessage)]
        [Display(Name = "Име")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = DataConstants.RequiredErrorMessage)]
        [StringLength(DescriptionMaxLength,MinimumLength = DescriptionMinLength,ErrorMessage = DataConstants.LengthErrorMessage)]
        [Display(Name = "Описание")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = DataConstants.RequiredErrorMessage)]
        [StringLength(ImgUrlMaxLength, MinimumLength = ImgUrlMinLength, ErrorMessage = DataConstants.LengthErrorMessage)]
        [Display(Name = "Снимка-URL")]
        public string ImgUrl { get; set; } = string.Empty;

        [Required(ErrorMessage = DataConstants.RequiredErrorMessage)]
        [Range(PriceMin, PriceMax,ErrorMessage = DataConstants.RangeErrorMessage)]
        [Display(Name = "Цена")]
        public decimal Price { get; set; }

        public bool IsActive { get; set; }

        [Required(ErrorMessage = DataConstants.RequiredErrorMessage)]
        [Range(AmountMin, AmountMax,ErrorMessage = DataConstants.RangeErrorMessage)]
        [Display(Name = "Количество")]
        public int Amount { get; set; }


        [Required(ErrorMessage = DataConstants.RequiredErrorMessage)]
        [Display(Name = "Колекция")]
        public int ClothCollectionId { get; set; }

        public ICollection<ClothCollectionModel> ClothCollectionModels { get; set; } = new List<ClothCollectionModel>();


        [Required(ErrorMessage = DataConstants.RequiredErrorMessage)]
        [Display(Name = "Размер на облеклото")]
        public int SizeId { get; set; }

        public ICollection<SizeModel> SizeModels { get; set; } = new List<SizeModel>();

        [Required(ErrorMessage = DataConstants.RequiredErrorMessage)]
        [Display(Name = "Тип-облекло")]
        public int TypePersonId { get; set; }

        public ICollection<TypePersonModel> TypePersonModels { get; set; } = new List<TypePersonModel>();

        public Guid BuyerId { get; set; }

    }
}
