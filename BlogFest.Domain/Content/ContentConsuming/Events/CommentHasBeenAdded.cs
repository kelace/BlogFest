using BlogFest.Domain.Base;

namespace BlogFest.Domain.Content.ContentConsuming
{
    public class CommentHasBeenAdded : DomainEvent
    {
        public Guid PostId { get; set; }
        public Guid UserId { get; set; }
        public string Content { get; set; }
    }
}
