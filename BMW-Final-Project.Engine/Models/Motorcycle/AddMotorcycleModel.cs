namespace BMW_Final_Project.Engine.Models.Motorcycle
{
    public class AddMotorcycleModel : EditMotorcycleModel
    {
        public bool IsActive { get; set; }

        public string BuyerId { get; set; } = string.Empty;
    }
}
