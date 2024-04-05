namespace BMW_Final_Project.Engine.Models.Event
{
    public class AllEventsModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string StartEvent { get; set; } = string.Empty;

        public string EndEvent { get; set; } = string.Empty;

        public string PlaceOfTheEvent { get; set; } = string.Empty;

        public string ImgUrl { get; set; } = string.Empty;

    }
}
