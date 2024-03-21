namespace BlogFest.Application.Services.Configuration.Queries.DTOs
{
    public class UserConfigurationDto
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImagePath { get; set; }
        public Guid? PhotoFileId { get; set; }
        public Guid UserId { get; set; }
        public string UserBio { get; set; }
    }
}
