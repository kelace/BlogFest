namespace BlogFest.Domain.Users
{
    public class UserInformation
    {
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        public string Bio { get; internal set; }
        public Guid? PhotoId { get; internal set; }

        public UserInformation(string firstName, string lastName, Guid? photoId = null, string bio = "")
        {
            FirstName = firstName;
            LastName = lastName;
            Bio = bio;
            PhotoId = photoId;
        }
    }
}
