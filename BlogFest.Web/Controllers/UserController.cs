using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BlogFest.Application.Users.Queries.GetUserInfo;
using BlogFest.Domain.Users;
using BlogFest.Infrastructure.Persistance;
using BlogFest.Models.User;
using System.Net;
using BlogFest.Application.Services.Users.DTOs;
using BlogFest.Application.Abstract;
using BlogFest.Application.Services.Users.Queries.GetUserPageByName;
using BlogFest.Application.Services.Users.Queries.GetAllNotification;
using BlogFest.Application.Services.Users.ReadAllNotifications;

namespace BlogFest.Controllers
{
    [Route("/user")]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserRepository _userRepository;
        private readonly IMediator _mediator;
        private readonly IUserContext _userContext;
        public UserController(ApplicationDbContext context, IUserRepository userRepository, IMediator mediator, IUserContext userContext)
        {
            _context = context;
            _userRepository = userRepository;
            _mediator = mediator;
            _userContext = userContext;
        }

        [Route("/user/{name}")]
        public async Task<ActionResult> IndexByName(string name, int page = 1)
        {
            var post = await _mediator.Send<UserPageDTO>(new GetUserPageByNameQuery
            {
                Name = name,
                CurrentUserId = _userContext.CurrentUserId,
                Page = page
            });

            if (post == null)
            {
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return View("UserNotFound");
            }

            if (!post.User.IsActive) return View("UserDeactivated");

            return View("Index", post);
        }

        [Route("{id:guid}")]
        public async Task<ActionResult> Index(Guid Id, int page = 1)
        {
            UserViewModel model;

            var post = await _mediator.Send<UserPageDTO>(new GetUserPageQuery
            {
                Id = Id,
                CurrentUserId = _userContext.CurrentUserId,
                Page = page
            });

            if (post == null)
            {
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return View("UserNotFound");
            }

            if (!post.User.IsActive) return View("UserDeactivated");

            return View(post);
        }

        [Route("notification")]
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Notification()
        {
            await _mediator.Send(new ReadAllNotificationsCommand());
            var result = await _mediator.Send<List<NotificationDTO>>(new GetAllUserNotificationQuery());
            return View(result);
        }

        [Route("main")]
        [Authorize]
        public async Task<ActionResult> MainUserPage(int page = 1)
        {
            UserViewModel model;

            if(!_userContext.IsAuthenticated) return Unauthorized();

            var user = await _mediator.Send<UserPageDTO>(new GetUserPageQuery
            {
                Id = _userContext.CurrentUserId,
                CurrentUserId = _userContext.CurrentUserId,
                Page = page

            });

            if (user == null)
            {
                //Response.StatusCode = (int)HttpStatusCode.NotFound;
                //foreach (var cookie in Request.Cookies.Keys)
                //{
                //    Response.Cookies.Delete(cookie);
                //}
                return View("UserNotFound");
            }

            return View("Index", user);
        }
        
    }
}
