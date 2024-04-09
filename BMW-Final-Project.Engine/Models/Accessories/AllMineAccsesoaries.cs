namespace BMW_Final_Project.Engine.Models.Accessories
{
    public class AllMineAccsesoaries
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Price { get; set; } = string.Empty;

        public Guid BuyerId { get; set; }

        public string ImgUrl { get; set; } = string.Empty;

    }
}
