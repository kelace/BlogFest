using BlogFest.Domain.Base;
using BlogFest.Domain.Content;

namespace BlogFest.Domain.Content.ContentConsuming
{
    public class Post : Entity
    {
        public PostStatus Status { get; private set; }
        public string Slug { get; private set; }

        public Post(Guid Id, PostStatus status, string slug) : base(Id)
        {

            Status = status;
			Slug = slug;

		}
        public bool IsAllowedToInteract()
        {
            if (Status == PostStatus.Published) return true;
            return false;
        }


    }
}
