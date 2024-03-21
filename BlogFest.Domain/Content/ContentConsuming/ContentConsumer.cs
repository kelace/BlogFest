using BlogFest.Domain.Base;

namespace BlogFest.Domain.Content.ContentConsuming
{
    public class ContentConsumer : AggregateRoot
    {
        private bool _isUserAllowedToComment;
        private Post _post;

        public ContentConsumer(Guid id, bool isUserAllowedToComment, Post post) : base(id)
        {
            _isUserAllowedToComment = isUserAllowedToComment;
            _post = post;
        }

        public Result<bool, Error> PutLike()
        {
            AddEvent(new LikeHasBeenPutEvent
            {
                PostId = _post.Id,
                UserId = Id
            });

            return true;
        }

        public Result<bool, Error> PutDislike()
        {
            AddEvent(new DislikeHasBeenPutEvent
            {
                PostId = _post.Id,
                UserId = Id
            });

            return true;
        }

        public Result<SuccessInfo, Error> WriteComment(string comment)
        {
            if (!_isUserAllowedToComment) return PostErros.UserNotAllowedWriteComment;
            if (!_post.IsAllowedToInteract()) return PostErros.NotPossibleToInteract;

            AddEvent(new CommentHasBeenAdded
            {
                PostId = _post.Id,
                UserId = Id,
                Content = comment
            });

            return new SuccessInfo
            {
                Id = _post.Id,
                Slug = _post.Slug,
                Message = "Comment has been published"
            };
        }
    }
}
