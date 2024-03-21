using BlogFest.Application.Behaviors.Abstract;
using BlogFest.Application.Services.Abstract;
using BlogFest.Domain.Base;
using MediatR;

namespace BlogFest.Application.Services.Content.Commands.CreateComment
{
    public class CreateCommentCommand : IRequest<Result<SuccessInfo, Error>>, IApplicationCommand, ICacheRefreshable
	{
        public string CommentContent { get; set; }
        public Guid PostId { get; set; }
        public Guid UserId { get; set; }
		public string RefreashbleKey => CacheConstants.PostSlugCacheKey;
	}
}