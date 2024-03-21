namespace BlogFest.Application.Services.Users.DTOs
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string Bio { get; set; }
        public bool IsActive { get; set; }
    }
}
