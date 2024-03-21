using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using BlogFest.Infrastructure.Persistance;
using System.Security.Claims;
using BlogFest.Application.Services.Users.DTOs;
using BlogFest.Application.Abstract;

namespace BlogFest.Services.UserContext
{
    public class UserContext : IUserContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ApplicationDbContext _context;
        private readonly IMemoryCache _memoryCache;
        public UserContext(IHttpContextAccessor httpContextAccessor, ApplicationDbContext context, IMemoryCache memoryCache)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
            _memoryCache = memoryCache;
        }
        public async Task<bool> IsCurrentUserAdmin()
        {
            var id = CurrentUserId;

            if(id == Guid.Empty) return false;

            var result =  await (from u in _context.Users
                          join ur in _context.UserRoles on u.Id equals ur.UserId into urr
                          from i in urr.DefaultIfEmpty()
                          join r in _context.Roles on i.RoleId equals r.Id into urp
                          from c in urp.DefaultIfEmpty()
                          where u.Id == id
                          select (u != null && c.Name == "Admin") ? true : false).FirstOrDefaultAsync();

            return result;
        }

        public async Task<UserDTO> GetUser()
        {
            return await _context.Users.Select(x => new UserDTO { Name = x.Name, Id = x.Id}).FirstOrDefaultAsync(x => x.Id == CurrentUserId);
        }

        public Guid CurrentUserId
        {
            get
            {
                var userClaim = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
                if (userClaim != null)
                {
                    return Guid.Parse(userClaim.Value);
                }

                return Guid.Empty;
            }
        }

        public bool IsAuthenticated => _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;
    }
}
