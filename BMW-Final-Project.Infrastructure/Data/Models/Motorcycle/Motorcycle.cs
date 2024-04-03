using BMW_Final_Project.Infrastructure.Data.IdentityModels;
using BMW_Final_Project.Infrastructure.ValidationAttributes;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static BMW_Final_Project.Infrastructure.Constants.DataConstants.MotorcycleConstants;

namespace BMW_Final_Project.Infrastructure.Data.Models.Motorcycle
{
    [Comment("Motorcycles table")]
    public class Motorcycle
    {
        [Key]
        [Comment("Motorcycle identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxMotorcycleModelLength)]
        [Comment("Motorcycle model")]
        public string Model { get; set; } = string.Empty;

        [Required]
        [Comment("Motorcycle Type identifier")]
        public int TypeMotorId { get; set; }

        [ForeignKey(nameof(TypeMotorId))]
        public TypeMotor TypeMotor { get; set; } = null!;

        [Required]
        [Comment("Category identifier")]
        public int ColorCategoryId { get; set; }

        [ForeignKey(nameof(ColorCategoryId))]
        public ColorCategory ColorCategory { get; set; } = null!;

        [Required]
        [Range(MinMotorcycleKg, MaxMotorcycleKg)]
        [Comment("Motorcycle weight")]
        public int Kg { get; set; }

        [Required]
        [Range(MinMotorcycleTankCapacity, MaxMotorcycleTankCapacity)]
        [Comment("Motorcycle tank capacity")]
        public int TankCapacity { get; set; }

        [Required]
        [Range(MinMotorcycleHorsePowers, MaxMotorcycleHorsePowers)]
        [Comment("Motorcycle horse powers")]
        public int HorsePowers { get; set; }

        [Required]
        [Range(MinMotorcycleCC, MaxMotorcycleCC)]
        [Comment("Engine displacement")]
        public int CC { get; set; }

        [Required]
        [Comment("Motorcycle euro standard identifier")]
        public int StandardEuroId { get; set; }

        [ForeignKey(nameof(StandardEuroId))]
        public StandardEuro StandardEuro { get; set; } = null!;

        [Required]
        [Range(MinMotorcyclePrice, MaxMotorcyclePrice)]
        [Comment("Motorcycle price")]
        public decimal Price { get; set; }

        [IsBefore]
        [Required]
        [Comment("Motorcycle bought date and time")]
        public DateTime Year { get; set; }

        [Required]
        [MaxLength(MaxMotorcycleDtcLengthLength)]
        [Comment("Motorcycle dynamic traction control")]
        public string DTC { get; set; } = string.Empty;

        [Required]
        [MaxLength(MaxMotorcycleTransmissionLength)]
        [Comment("Motorcycle transmission box")]
        public string Transmission { get; set; } = string.Empty;

        [Required]
        [MaxLength(MaxMotorcycleFrontBrakeLength)]
        [Comment("Motorcycle front brake model")]
        public string FrontBreak { get; set; } = string.Empty;

        [Required]
        [MaxLength(MaxMotorcycleRearBrakeLength)]
        [Comment("Motorcycle rear brake model")]
        public string RearBreak { get; set; } = string.Empty;

        [Required]
        [Range(MinMotorcycleSeatLength, MaxMotorcycleSeatLength)]
        [Comment("Motorcycle seat height in mm")]
        public int SeatHeightMm { get; set; }

        [Required]
        [MaxLength(MaxMotorcycleImageUrlLength)]
        [Comment("Motorcycle photo")]
        public string ImageUrl { get; set; } = string.Empty;

        [Comment("Motorcycle ad status")]
        public bool IsActive { get; set; }

        [Required]
        [Comment("Motorcycle amount")]
        [Range(MaxMotorcycleAmount, MinMotorcycleAmount)]
        public int Amount { get; set; }

        [Required]
        [Comment("Buyer identifier")]
        public Guid BuyerId { get; set; } 


        [ForeignKey(nameof(BuyerId))]
        public ApplicationUser Buyer { get; set; } = null!;

        public ICollection<MotorcycleBuyers> MotorcycleBuyers { get; set; } = new List<MotorcycleBuyers>();
    }
}
