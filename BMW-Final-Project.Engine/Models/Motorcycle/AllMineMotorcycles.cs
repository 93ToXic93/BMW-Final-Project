namespace BMW_Final_Project.Engine.Models.Motorcycle
{
    public class AllMineMotorcycles
    {
        public int Id { get; set; }

        public string Model { get; set; } = string.Empty;

        public string ColorCategory { get; set; } = string.Empty;

        public string Price { get; set; } = string.Empty;

        public string Year { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        public bool IsActive { get; set; }

        public string BuyerId { get; set; } = string.Empty;

    }
}
