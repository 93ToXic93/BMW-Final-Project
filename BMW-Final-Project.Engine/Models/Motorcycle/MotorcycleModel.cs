namespace BMW_Final_Project.Engine.Models.Motorcycle
{
    public class MotorcycleModel
    {
        public int Id { get; set; }

        public string Model { get; set; } = string.Empty;

        public string Year { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        public string Price { get; set; } = string.Empty;

        public int Amount { get; set; }

    }
}