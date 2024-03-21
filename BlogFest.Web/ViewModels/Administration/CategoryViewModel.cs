namespace BlogFest.Web.ViewModels.Administration
{
    public class CategoryViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string EncodedTitle { get; set; }
        public bool Enabled { get; set; }
    }
}
