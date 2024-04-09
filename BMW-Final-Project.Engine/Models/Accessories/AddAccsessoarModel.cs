using System.ComponentModel.DataAnnotations;
using BMW_Final_Project.Infrastructure.Constants;
using static BMW_Final_Project.Infrastructure.Constants.DataConstants.AccessorConstants;

namespace BMW_Final_Project.Engine.Models.Accessories
{
    public class AddAccsessoarModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = DataConstants.RequiredErrorMessage)]
        [StringLength(MaxNameLength,MinimumLength = MinNameLength,ErrorMessage = DataConstants.LengthErrorMessage)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = DataConstants.RequiredErrorMessage)]
        [Range(MinPrice, MaxPrice)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = DataConstants.RequiredErrorMessage)]
        public int ItemTypeId { get; set; }

        [Required(ErrorMessage = DataConstants.RequiredErrorMessage)]
        public Guid BuyerId { get; set; }

        [Required(ErrorMessage = DataConstants.RequiredErrorMessage)]
        public bool IsActive { get; set; }

        [Required(ErrorMessage = DataConstants.RequiredErrorMessage)]
        [StringLength(UrlMaxLength,MinimumLength = UrlMinLength,ErrorMessage = DataConstants.LengthErrorMessage)]
        public string ImgUrl { get; set; } = string.Empty;

        [Range(MinAmount, MaxAmount)]
        [Required(ErrorMessage = DataConstants.RequiredErrorMessage)]
        public int Amount { get; set; }
    }
}
