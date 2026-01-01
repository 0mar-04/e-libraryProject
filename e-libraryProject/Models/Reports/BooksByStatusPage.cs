namespace e_libraryProject.Models.Reports
{
    public class BooksByStatusPage
    {
        public int TotalBooks { get; set; }
        public EBookStatus? MostCommonStatus { get; set; }
        public List<StatusGroup> Groups { get; set; } = new();
    }
}
