using BMW_Final_Project.Infrastructure.Constants;
using System.ComponentModel.DataAnnotations;
using static BMW_Final_Project.Infrastructure.Constants.DataConstants.AccessorConstants;

namespace BMW_Final_Project.Engine.Models.Accessories
{
    public class EditAccsesoarModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = DataConstants.RequiredErrorMessage)]
        [StringLength(MaxNameLength, MinimumLength = MinNameLength, ErrorMessage = DataConstants.LengthErrorMessage)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = DataConstants.RequiredErrorMessage)]
        [Range(MinPrice, MaxPrice)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = DataConstants.RequiredErrorMessage)]
        public int ItemTypeId { get; set; }

        [Required(ErrorMessage = DataConstants.RequiredErrorMessage)]
        [StringLength(UrlMaxLength, MinimumLength = UrlMinLength, ErrorMessage = DataConstants.LengthErrorMessage)]
        public string ImgUrl { get; set; } = string.Empty;

        [Range(MinAmount, MaxAmount)]
        [Required(ErrorMessage = DataConstants.RequiredErrorMessage)]
        public int Amount { get; set; }

        public ICollection<ItemTypeModel> ItemTypeModel { get; set; } = new List<ItemTypeModel>();
    }
}
