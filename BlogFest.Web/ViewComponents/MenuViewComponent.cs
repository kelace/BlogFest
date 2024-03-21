using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using BlogFest.Infrastructure.Persistance;
using BlogFest.Web.ViewModels.Menu;
using BlogFest.Application.Abstract;
using Microsoft.EntityFrameworkCore;

namespace BlogFest.Web.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;
        private readonly IMemoryCache _memoryCache;
        private readonly IUserContext _userContext;

        public MenuViewComponent(ApplicationDbContext context, IMemoryCache memoryCache, IUserContext userContext)
        {
            _context = context;
            _memoryCache = memoryCache;
            _userContext = userContext;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var unreadNotifications = await _context.Notifications.Where(x => !x.IsRead && x.UserId == _userContext.CurrentUserId).CountAsync();

            var model = new MenuViewModel
            {
                IsAdmin = await _userContext.IsCurrentUserAdmin(),
                IsAuthorized = _userContext.IsAuthenticated,
                UnreadNotificationsCount = unreadNotifications
            };

            return View(model);
        }
    }
}
