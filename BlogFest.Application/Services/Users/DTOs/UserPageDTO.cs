using BlogFest.Application.Services.Content.Queries.DTOs;

namespace BlogFest.Application.Services.Users.DTOs
{
    public class UserPageDTO
    {
        public bool IsAdmin { get; set; }
        public UserDTO User { get; set; }
        public List<PostDTO> Posts { get; set; }
        public bool IsUserAccount { get; set; }
        public int Page { get; set; }
        public int CommonAmount { get; set; }
        public  bool IsActive { get; set; }
    }
}
