using BMW_Final_Project.Infrastructure.Data.Models.Motorcycles;
using BMW_Final_Project.Infrastructure.ValidationAttributes;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static BMW_Final_Project.Infrastructure.Constants.DataConstants;
using static BMW_Final_Project.Infrastructure.Constants.DataConstants.MotorcycleConstants;
namespace BMW_Final_Project.Core.Models
{
    public class AddMotorcycleModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(MaxMotorcycleModelLength,MinimumLength = MinMotorcycleModelLength,ErrorMessage = LengthErrorMessage)]
        public string Model { get; set; } = string.Empty;

        public int TypeMotorId { get; set; }

        public ICollection<TypeMotorModel> TypeMotorModels { get; set; } = null!;

        public int ColorCategoryId { get; set; }

        public ICollection<ColorCategoryModel> ColorCategoryModels { get; set; } = null!;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [Range(MinMotorcycleKg, MaxMotorcycleKg,ErrorMessage = RangeErrorMessage)]
        public int Kg { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [Range(MinMotorcycleTankCapacity, MaxMotorcycleTankCapacity,ErrorMessage = RangeErrorMessage)]
        public int TankCapacity { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [Range(MinMotorcycleHorsePowers, MaxMotorcycleHorsePowers,ErrorMessage = RangeErrorMessage)]
        public int HorsePowers { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [Range(MinMotorcycleCC, MaxMotorcycleCC,ErrorMessage = RangeErrorMessage)]
        public int CC { get; set; }

        public int StandardEuroId { get; set; }

        public ICollection<StandardEuroModel> StandardEuroModels { get; set; } = null!;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [Range(MinMotorcyclePrice, MaxMotorcyclePrice,ErrorMessage = RangeErrorMessage)]
        public decimal Price { get; set; }

        [IsBefore(ErrorMessage = DataFormatError)]
        [Required(ErrorMessage = RequiredErrorMessage)]
        public DateTime Year { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(MaxMotorcycleDtcLengthLength,MinimumLength = MinMotorcycleDtcLengthLength,ErrorMessage = LengthErrorMessage)]
        public string DTC { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(MaxMotorcycleTransmissionLength,MinimumLength = MinMotorcycleTransmissionLength,ErrorMessage = LengthErrorMessage)]
        public string Transmission { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(MaxMotorcycleFrontBrakeLength,MinimumLength = MinMotorcycleFrontBrakeLength,ErrorMessage = LengthErrorMessage)]
        public string FrontBreak { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(MaxMotorcycleRearBrakeLength,MinimumLength = MinMotorcycleRearBrakeLength,ErrorMessage = LengthErrorMessage)]
        public string RearBreak { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [Range(MinMotorcycleSeatLength, MaxMotorcycleSeatLength,ErrorMessage = RangeErrorMessage)]
        public int SeatHeightMm { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(MaxMotorcycleImageUrlLength,MinimumLength = MinMotorcycleImageUrlLength,ErrorMessage = LengthErrorMessage)]
        public string ImageUrl { get; set; } = string.Empty;

        public bool IsActive { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [Range(MaxMotorcycleAmount,MinMotorcycleAmount,ErrorMessage = RangeErrorMessage)]
        public int Amount { get; set; }

        public string BuyerId { get; set; } = string.Empty;

    }
}
