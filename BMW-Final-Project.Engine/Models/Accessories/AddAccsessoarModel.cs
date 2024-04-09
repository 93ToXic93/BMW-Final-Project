namespace BMW_Final_Project.Engine.Models.Accessories
{
    public class AddAccsessoarModel : EditAccsesoarModel
    {
        public Guid BuyerId { get; set; }

        public bool IsActive { get; set; }
    }
}
