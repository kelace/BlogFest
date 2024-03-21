using BlogFest.Domain.Base;
using BlogFest.Domain.Content;


namespace BlogFest.Domain.Content.ContentCreating
{
    public class PostHasBeenEdited : DomainEvent
    {
        public Guid PostId { get; set; }
        public string ContentText { get; set; }
        public string ContentHTML { get; set; }
        public List<Guid> Categories { get; set; } = new List<Guid>();
        public Guid? ImageId { get; set; }
        public PostStatus Status { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
    }
}
