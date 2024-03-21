using BlogFest.Domain.Base;
using BlogFest.Domain.Content;

namespace BlogFest.Domain.Content.ContentCreating
{
    public class PostHasBeenCreated : DomainEvent
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ContentHTML { get; set; }
        public PostStatus Status { get; set; }
        public Guid UserId { get; set; }
        public List<Guid> Categories { get; set; }
        public string Slug { get; set; }
    }
}
