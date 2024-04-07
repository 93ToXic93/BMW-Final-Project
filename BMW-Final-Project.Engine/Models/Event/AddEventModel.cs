namespace BMW_Final_Project.Engine.Models.Event
{
    public class AddEventModel : EditEventModel
    {
        public Guid JoinerId { get; set; }

        public bool IsActive { get; set; }
    }
}
