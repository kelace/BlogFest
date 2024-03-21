namespace BlogFest.Web.ViewModels.Content
{
    public class CategorySideBarViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string EncodedTitle { get; set; }
        public bool Enabled { get; set; }
        public int Count { get; set; }
    }
}
