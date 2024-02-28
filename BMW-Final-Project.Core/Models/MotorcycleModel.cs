namespace BMW_Final_Project.Core.Models
{
    public class MotorcycleModel
    {
        public int Id { get; set; }

        public string Model { get; set; } = string.Empty;

        public string TypeMotor { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public string Year { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        public bool IsActive { get; set; }

        public string BuyerId { get; set; } = string.Empty;

    }
}
