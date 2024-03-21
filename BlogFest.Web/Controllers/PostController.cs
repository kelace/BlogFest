using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BlogFest.Domain.Base;
using BlogFest.Models.Thread;
using BlogFest.Web.Extensions;
using BlogFest.Web.ViewModels.Content;
using BlogFest.Web.ViewModels.Thread;
using BlogFest.Application.Services.Content.Queries.DTOs;
using BlogFest.Application.Services.Content.Queries.GetThreadInfoQuery;
using BlogFest.Application.Services.Content.Queries.GetPostCommentsQuery;
using BlogFest.Application.Services.Content.Queries.GetPostReactionQuery;
using BlogFest.Application.Services.Content.Commands.PutDislike;
using BlogFest.Application.Services.Content.Commands.IncreaseLike;
using BlogFest.Application.Services.Content.Queries.GetPostInfoForEdit;
using BlogFest.Application.Services.Content.Commands.CreateDraftPost;
using BlogFest.Application.Services.Content.Queries.GetAllUserThreadsQuery;
using BlogFest.Application.Services.Content.Commands.PublishPost;
using BlogFest.Web.Filters;
using BlogFest.Application.Services.Content.Commands.EditPost;
using BlogFest.Application.Services.Content.Commands.CreateComment;
using BlogFest.Application.Services.Content.Commands.UploadTitleImage;
using BlogFest.Application.Abstract;
using BlogFest.Application.Services.Content.Queries.GetPostByTitle;
using BlogFest.Application.Services.Media.Results;

namespace BlogFest.Controllers
{
    [Route("post")]
    public class PostController : Controller
    {
        private readonly IUserContext _userContext;
        private readonly ILogger _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public PostController
            (
            IUserContext userContext, 
            IMediator mediator,
            IMapper mapper
			)
        {
            _userContext = userContext;
            _mediator = mediator;
            _mapper = mapper;
		}

        [HttpGet]
        [Route( "{slug}")]
        public async Task<ActionResult> GetBySlug(string slug)
        {
            var model = await _mediator.Send<PostPageDTO>(new GetPostByTitleQuery
            {
                Slug = slug
            });

            return View("Index", model);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<ActionResult> Index(Guid Id)
        {
            var model = await _mediator.Send<PostPageDTO>(new GetPostQuery
            {
                PostId = Id
            });

            if(model == null)
            {
                Response.StatusCode = StatusCodes.Status404NotFound;
                return View("NotFound");
            }

            return View(model);
        }

        [HttpGet]
        [Route("comment")]
		public async Task<IActionResult> GetPostComments(Guid postId, int Offset)
        {
            var result = await _mediator.Send<PostCommentsDTO>(new GetPostCommentsQuery
            {
                PostId = postId,
                Offset = Offset
			});

            return PartialView("_GetPostComments", result);
        }

		[HttpPut]
		[Route("post-dislike")]
		[Authorize]
		public async Task<IActionResult> PutDislike(Guid PostId)
		{
			var result = await _mediator.Send<Result<bool, Error>>(new PutDislikeCommand
			{
				PostId = PostId
			});

			var reactions = await _mediator.Send<ReactionDTO>(new GetPostReactionQuery
			{
				PostId = PostId
			});

			var reactionVm = new ReactionViewModel
			{
				LikesCount = reactions.LikesCount,
				DislikesCount = reactions.DislikesCount,
				Type = reactions.Type,
			};

			var htmlResult = await this.RenderViewAsync<ReactionViewModel>("_ReactionButton", reactionVm, true);

			return Json(new { result = true, htmlResult = htmlResult });
		}

		[HttpPut]
        [Route("post-like")]
        [Authorize]
        public async Task<IActionResult> IncreaseLike(Guid PostId)
        {
            var result = await _mediator.Send<Result<bool, Error>>(new IncreaseLikeCommand
            {
                PostId = PostId
            });

			var reactions = await _mediator.Send<ReactionDTO>(new GetPostReactionQuery
			{
				PostId = PostId
			});

			var reactionVm = new ReactionViewModel
            {
                LikesCount = reactions.LikesCount,
                DislikesCount = reactions.DislikesCount,
                Type = reactions.Type,
			};

      		var htmlResult = await this.RenderViewAsync<ReactionViewModel>("_ReactionButton", reactionVm, true);

            return Json(new { result = true, htmlResult = htmlResult });
        }

		[HttpGet]
        [Route("edit")]
        [Authorize]
        public async Task<IActionResult> EditPost(string slug)
        {

            var result = await _mediator.Send<PostEditDTO>(new GetPostInfoForEditQuery
            {
                Slug = slug
            });

            var model = _mapper.Map<EditPostViewModel>(result);
            return View(model);
        }

        [HttpGet]
        [Route("create")]
        [Authorize]
        public async Task<IActionResult> CreatePost()
        {
 
            var result = await _mediator.Send(new CreateDraftPostCommand
            {

                UserId = _userContext.CurrentUserId,

            });

            return result.Match<IActionResult>(x =>
            {
                //model.PostId = result.Value;
                return RedirectToAction("EditPost", new {slug = result.Value.Slug});
            }, x =>
            {
                Response.StatusCode = 400;
         
                return Json(new { error = x });
            } );
        }

        [HttpGet]
        [Route("explore")]
        public async Task <ActionResult> Explore(int page = 1)
        {

            var posts = await  _mediator.Send<ExplorePostsDTO>(new GetAllUserPostsQuery
            {
                Offset = page
            });

            posts.PageIndex = page;

            return View(posts);
        }

        [Route("publish")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        [DefaultValidateModel]
        public async Task<IActionResult> PublishPost(Guid postId)
        {
            var result = await _mediator.Send(new PublishPostCommand
            {
                PostId = postId
            });

            return result.Match<IActionResult>(x => Json(new { result = true, message = "Post has been published" }), x => Json(new {result = false, message = x.Description}));
        }

        [Route("edit")]
        [HttpPut]
        [ValidateAntiForgeryToken]
        [Authorize]
        [DefaultValidateModel]
        public async Task<IActionResult> EditPost(EditPostViewModel model)
        {
            var result = await _mediator.Send(new EditPostCommand
            {
                Title = model.Title,
                ContentText = model.ContentText,
                ContentHTML = model.ContentHTML,
                Categories = model.UpdateCategories,
                PostId = model.Id,
                ImageId = model.ImageId,
                Status =  model.Status 
            });

            return result.Match<IActionResult>(x =>  Json(new  { result = true, message = "Post has been edited" }), x =>  Json(new { result = false, message = x}));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [DefaultValidateModel]
        [Route("comment")]
        [Authorize]
        public async Task<IActionResult> CreateComment(CreateCommentViewModel model)
        {
            var result = await _mediator.Send(new CreateCommentCommand
            {
                UserId = _userContext.CurrentUserId,
                CommentContent = model.CommentContent,
                PostId = model.PostId,
            });

            return result.Match<IActionResult>(x => Json(new { result = true, message = x.Message }), x => Json(new {result = false, error = x.Description } ));
        }

        [HttpPost]
        [Authorize]
        [Route("upload-title-image")]
        [DefaultValidateModel]
        public async Task<IActionResult> UploadTitleImage(UploadImageTitleViewModel model)
        {
            var result = await _mediator.Send<Result<SuccesUploadResult, Error>>(new UploadTitleImageCommand
            {
                Image = await model.GetImageTitleBytesAsync(),
                PostId = model.PostId,
            });

            return result.Match<IActionResult>(x => Json(new { result = true, imageId = x.ImageId ,imageUrl = "/media/" + x.ImagePath  }), x => Json(new { result = false, error = x }));
        } 
    }
}
