using BlogFest.Domain.Base;

namespace BlogFest.Domain.Content.ContentConsuming
{
    public class PostComment : Entity
    {
        public string Text { get; private set; }
        public Guid ThreadId { get; private set; }
        public Guid UserId { get; private set; }

        public PostComment(Guid id, string text, Guid threadId, Guid userId) : base(id)
        {
            Text = text;
            ThreadId = threadId;
            UserId = userId;
        }

        public PostComment(string text, Guid threadId, Guid userId) : this(Guid.NewGuid(), text, threadId, userId)
        {
        }

        public void IncreaseIikes()
        {

        }

        public void IncreaseDislikes()
        {

        }

    }
}
