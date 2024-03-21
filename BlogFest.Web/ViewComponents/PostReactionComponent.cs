using BlogFest.Application.Services.Content.Queries.DTOs;
using BlogFest.Application.Services.Content.Queries.GetPostReactionQuery;
using BlogFest.Web.ViewModels.Content;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BlogFest.Web.ViewComponents
{
    public class PostReactionViewComponent : ViewComponent
    {
        private readonly IMediator _mediator;
        public PostReactionViewComponent(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid id)
        {
            var result =  await _mediator.Send<ReactionDTO>(new GetPostReactionQuery
            {
                PostId = id
            });

            return View(new ReactionViewModel
            {
                LikesCount = result.LikesCount,
                DislikesCount = result.DislikesCount,
                Type = result.Type,
            });
        }
    }
}
