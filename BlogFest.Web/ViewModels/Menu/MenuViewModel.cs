namespace BlogFest.Web.ViewModels.Menu
{
    public class MenuViewModel
    {
        public bool IsAuthorized { get; set; }
        public bool IsAdmin { get; set; }
        public int UnreadNotificationsCount { get; set; }
    }
}
