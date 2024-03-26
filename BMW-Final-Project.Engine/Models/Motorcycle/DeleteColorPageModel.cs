namespace BMW_Final_Project.Engine.Models.Motorcycle
{
    public class DeleteColorPageModel
    {
        public ICollection<DeleteColorModel> Colors { get; set; } = new List<DeleteColorModel>();

        public int CurrentPage { get; set; } = 1;

        public int TotalCount { get; set; }

        public int ColorsPerPage { get; set; }

    }
}
