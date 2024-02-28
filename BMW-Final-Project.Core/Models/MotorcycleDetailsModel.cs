using BMW_Final_Project.Infrastructure.Data.Models;
using BMW_Final_Project.Infrastructure.ValidationAttributes;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BMW_Final_Project.Core.Models
{
    public class MotorcycleDetailsModel : MotorcycleModel
    {

        public int TypeMotorId { get; set; }

        public string TypeMotor { get; set; } = string.Empty;

        public int Kg { get; set; }

        public int TankCapacity { get; set; }

        public int HorsePowers { get; set; }

        public int CC { get; set; }

        public int StandardEuroId { get; set; }

        public string StandardEuro { get; set; } = string.Empty;

        public string Price { get; set; } = string.Empty;

        public string DTC { get; set; } = string.Empty;

        public string Transmission { get; set; } = string.Empty;

        public string FrontBreak { get; set; } = string.Empty;

        public string RearBreak { get; set; } = string.Empty;

        public int SeatHeightMm { get; set; }

        public bool IsActive { get; set; }

        public int Amount { get; set; }

    }
}
