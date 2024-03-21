using BlogFest.Application.Behaviors.Abstract;
using BlogFest.Application.Services.Abstract;
using BlogFest.Application.Services.Content.Queries.DTOs;
using MediatR;


namespace BlogFest.Application.Services.Content.Queries.GetPostByTitle
{
    public class GetPostByTitleQuery : IRequest<PostPageDTO>, ICacheable, IApplicationQuery
    {
        public string Slug { get; set; }
        public string Key => $"post-{Slug}";
    }
}
