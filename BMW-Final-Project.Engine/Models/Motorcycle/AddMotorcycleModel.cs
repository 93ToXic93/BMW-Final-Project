using System.ComponentModel.DataAnnotations;
using BMW_Final_Project.Infrastructure.ValidationAttributes;
using static BMW_Final_Project.Infrastructure.Constants.DataConstants;
using static BMW_Final_Project.Infrastructure.Constants.DataConstants.MotorcycleConstants;
namespace BMW_Final_Project.Engine.Models.Motorcycle
{
    public class AddMotorcycleModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(MaxMotorcycleModelLength, MinimumLength = MinMotorcycleModelLength, ErrorMessage = LengthErrorMessage)]
        [Display(Name = "Модел")]
        public string Model { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [Display(Name = "Тип на мотора")]
        public int TypeMotorId { get; set; }

        public ICollection<TypeMotorModel> TypeMotorModels { get; set; } = null!;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [Display(Name = "Цвят на мотора")]
        public int ColorCategoryId { get; set; }

        public ICollection<ColorCategoryModel> ColorCategoryModels { get; set; } = null!;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [Range(MinMotorcycleKg, MaxMotorcycleKg, ErrorMessage = RangeErrorMessage)]
        [Display(Name = "Тегло на мотора")]
        public int Kg { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [Range(MinMotorcycleTankCapacity, MaxMotorcycleTankCapacity, ErrorMessage = RangeErrorMessage)]
        [Display(Name = "Капацитет на резервоара")]
        public int TankCapacity { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [Range(MinMotorcycleHorsePowers, MaxMotorcycleHorsePowers, ErrorMessage = RangeErrorMessage)]
        [Display(Name = "Конски сили")]
        public int HorsePowers { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [Range(MinMotorcycleCC, MaxMotorcycleCC, ErrorMessage = RangeErrorMessage)]
        [Display(Name = "Кубични сили")]
        public int CC { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [Display(Name = "Евро стандарт")]
        public int StandardEuroId { get; set; }

        public ICollection<StandardEuroModel> StandardEuroModels { get; set; } = null!;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [Range(MinMotorcyclePrice, MaxMotorcyclePrice, ErrorMessage = RangeErrorMessage)]
        [Display(Name = "Цена")]
        public decimal Price { get; set; }

        [IsBefore(ErrorMessage = DataFormatError)]
        [Required(ErrorMessage = RequiredErrorMessage)]
        [Display(Name = "Година на производството")]
        public DateTime Year { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(MaxMotorcycleDtcLengthLength, MinimumLength = MinMotorcycleDtcLengthLength, ErrorMessage = LengthErrorMessage)]
        [Display(Name = "Динамичен контрол на сцеплението")]
        public string DTC { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(MaxMotorcycleTransmissionLength, MinimumLength = MinMotorcycleTransmissionLength, ErrorMessage = LengthErrorMessage)]
        [Display(Name = "Скоростна кутия")]
        public string Transmission { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(MaxMotorcycleFrontBrakeLength, MinimumLength = MinMotorcycleFrontBrakeLength, ErrorMessage = LengthErrorMessage)]
        [Display(Name = "Предна спирачка")]
        public string FrontBreak { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(MaxMotorcycleRearBrakeLength, MinimumLength = MinMotorcycleRearBrakeLength, ErrorMessage = LengthErrorMessage)]
        [Display(Name = "Задна спирачка")]
        public string RearBreak { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [Range(MinMotorcycleSeatLength, MaxMotorcycleSeatLength, ErrorMessage = RangeErrorMessage)]
        [Display(Name = "Височина на седалката")]
        public int SeatHeightMm { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(MaxMotorcycleImageUrlLength, MinimumLength = MinMotorcycleImageUrlLength, ErrorMessage = LengthErrorMessage)]
        [Display(Name = "URL на снимката")]
        public string ImageUrl { get; set; } = string.Empty;

        public bool IsActive { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [Range(MinMotorcycleAmount, MaxMotorcycleAmount, ErrorMessage = RangeErrorMessage)]
        [Display(Name = "Брой мотори")]
        public int Amount { get; set; }

        public string BuyerId { get; set; } = string.Empty;

    }
}
