namespace e_libraryProject.Models.Reports
{
    public class StatusGroup
    {
        public EBookStatus Status { get; set; }
        public int Count { get; set; }
        public List<BookItem> Books { get; set; } = new();
    }
}
