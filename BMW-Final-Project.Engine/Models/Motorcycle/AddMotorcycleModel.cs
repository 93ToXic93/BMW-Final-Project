namespace BMW_Final_Project.Engine.Models.Motorcycle
{
    public class AddMotorcycleModel : EditMotorcycleModel
    {
        public bool IsActive { get; set; }

        public Guid BuyerId { get; set; }
    }
}
