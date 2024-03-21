using MediatR;
using BlogFest.Domain.Base;
using BlogFest.Domain.Content;
using BlogFest.Application.Behaviors.Abstract;
using BlogFest.Application.Services.Abstract;

namespace BlogFest.Application.Services.Content.Commands.EditPost
{
    public class EditPostCommand : IRequest<Result<SuccessInfo, Error>>, IApplicationCommand, ICacheRefreshable
    {
        public string ContentHTML { get; set; }
        public string ContentText { get; set; }
        public string Title { get; set; }
        public List<Guid> Categories { get; set; }
        public Guid PostId { get; set; }
        public Guid? ImageId { get; set; }
        public PostStatus? Status { get; set; }
        public string RefreashbleKey => CacheConstants.PostSlugCacheKey;
    }
}
