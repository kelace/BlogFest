using BlogFest.Domain.Content;

namespace BlogFest.Application.Services.Content.Queries.DTOs
{
    public class PostDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public DateTime DateCreated { get; set; }
        public PostStatus Status { get; set; }
        public string ImagePath { get; set; }
        public string Slug { get; set; }
        
    }
}
