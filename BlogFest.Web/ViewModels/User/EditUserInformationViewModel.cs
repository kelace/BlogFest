namespace BlogFest.Web.ViewModels.User
{
    public class EditUserInformationViewModel
    {
        public Guid UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Name { get; set; }
        public Guid? PhotoId { get; set; }
        public string? Bio { get; set; }
    }
}
