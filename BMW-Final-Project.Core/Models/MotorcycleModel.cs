using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BMW_Final_Project.Core.Models
{
    public class MotorcycleModel
    {
        public int Id { get; set; }

        public string Model { get; set; } = string.Empty;

        public string TypeMotor { get; set; } = string.Empty;

        public string Year { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

    }
}
