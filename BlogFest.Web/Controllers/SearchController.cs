using Microsoft.AspNetCore.Mvc;
using BlogFest.Application;
using MediatR;
using BlogFest.Application.Services.Content.Queries.GetPostByTitle;
using BlogFest.Application.Services.Content.Queries.GetPostsByCategory;
using BlogFest.Application.Services.Search.Queries.DTOs;
using BlogFest.Application.Services.Search.Queries.SearchContent;

namespace BlogFest.Web.Controllers
{
    [Route("/search")]
    public class SearchController : Controller
    {
        private readonly IMediator _mediator;
        public SearchController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet] 
        public async Task<IActionResult> Index(string key, int page = 1)
        {
            var result = await _mediator.Send(new SearchContentQuery
            {
                Key = key,
                Page = page
            });

            return View(result);
        }

        [HttpGet]
        [Route("category")]
        public async Task<IActionResult> Category(string key, int page = 1)
        {
            var posts = await _mediator.Send(new GetPostsByCategoryQuery
            {
                CategoryTitle = key,
                Page = page
            });

            var result = posts.Select(x => new SearchItemDTO
            {
                Id = x.Id,
                Title = x.Title,
                SearchItemType = SearchItemType.Post,
                ImagePath = x.ImagePath,
                Slug = x.Slug,
                UserName = x.UserName,
                Content = x.Text
            }).ToList();

            return View("Index", new SearchDTO
            {
                SearchResult = result
            });
        }
    }
}
