namespace BlogFest.Domain.Administration
{
    public class UserSettings
    {
        public Guid UserId { get; set; }
        public bool IsAllowedToComment { get; set; }
        public bool IsAllowedToCreateThread { get; set; }
        public string UserRole { get; set; }
        public string UserStatus { get; set; }
        public bool IsActive { get; set; }
    }
}
