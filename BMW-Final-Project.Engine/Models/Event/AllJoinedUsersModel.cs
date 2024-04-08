namespace BMW_Final_Project.Engine.Models.Event
{
    public class AllJoinedUsersModel
    {

        public string Name { get; set; } = string.Empty;

        public string ImgUrl { get; set; } = string.Empty;
        public ICollection<JoinersModel> Joiners { get; set; } = new List<JoinersModel>();

        public int CurrentPage { get; set; } = 1;

        public int TotalCount { get; set; }

        public int ColorsPerPage { get; set; }

    }
}
