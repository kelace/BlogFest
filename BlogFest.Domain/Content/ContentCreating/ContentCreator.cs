using BlogFest.Domain.Base;
using BlogFest.Domain.User;

namespace BlogFest.Domain.Content.ContentCreating
{
    public class ContentCreator : AggregateRoot
    {
        public bool IsUserAllowedToCreatePost { get; private set; }
        public List<Post> Posts { get; set; }

        public ContentCreator(Guid id, bool isUserAllowedToCreatePost, List<Post> posts) : base(id)
        {
            IsUserAllowedToCreatePost = isUserAllowedToCreatePost;
            Posts = posts;
        }

        public Result<SuccessInfo, Error> PublishPost(Guid postId, string content, string contentHTML, string title,string slug, List<Guid> categories = null, Guid? imageId = null, PostStatus status = null)
        {
            var ediResult = EditPost(postId, content, contentHTML, title, slug, categories,imageId, status);

            if (ediResult.IsError) return ediResult;

            var pubblishResult = PublishPost(postId);

            return pubblishResult;
        }        
        public Result<SuccessInfo, Error> PublishPost(Guid id)
        {
            if (!IsUserAllowedToCreatePost) return UserErrors.NotAllowedToCreatePost;
            if (!IsPostExist(id)) return UserErrors.PostDoesntExist;

            var post = GetPostById(id);

            post.Publish();

            AddEvent(new PostHasBeenPublishedEvent
            {
                Id = id,
                Status = PostStatus.Published
            });

            return new SuccessInfo
            {
                Id = post.Id,
                Slug = post.Slug,
            };
        }

        public Result<SuccessInfo, Error> EditPost(Guid postId, string content, string contentHTML, string title,string slug, List<Guid> categories = null, Guid? imageId = null, PostStatus status = null)
        {
            var post = GetPostById(postId);

            if (post == null) return PostErros.PostDoesntExist;

            var editPostResult = post.Edit(content, contentHTML, title, slug, categories, status);

            if (editPostResult.IsError) return editPostResult; 

            var changeImageResult = post.ChangeImageTitle(imageId);

            AddEvent(new PostHasBeenEdited
            {
                PostId = post.Id,
                ContentHTML = post.ContentHTML,
                ContentText = post.ContentText,
                ImageId = changeImageResult,
                Categories = categories ?? new List<Guid>(),
                Title = post.Title,
                Status = post.Status,
                Slug = post.Slug,
            });

            return editPostResult;
        }

        public Result<Post, Error> CreateDraftPost(string slug)
        {
            if (!IsUserAllowedToCreatePost) return UserErrors.NotAllowedToCreatePost;
            var id = Guid.NewGuid();

            var post = new Post(id, Post.DefaultText, Post.DefaultTitle, PostStatus.Draft, Id, new List<Guid>(), slug);

            Posts.Add(post);

            AddEvent(new PostHasBeenCreated
            {
                Id = id,
                Title = Post.DefaultTitle,
                Content = Post.DefaultText,
                UserId = Id,
                Status = PostStatus.Draft,
                Slug = slug
            });

            return post;
        }

        private bool IsPostExist(Guid id)
        {
            return Posts.Any(x => x.Id == id);
        }
        private Post GetPostById(Guid id)
        {
            return Posts.FirstOrDefault(x => x.Id == id);
        }
    }
}
