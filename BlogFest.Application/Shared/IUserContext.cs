using BlogFest.Application.Services.Users.DTOs;

namespace BlogFest.Application.Abstract
{
    public interface IUserContext
    {
        Task<UserDTO> GetUser();
        Guid CurrentUserId { get; }
        bool IsAuthenticated { get; }
        Task<bool> IsCurrentUserAdmin();
    }
}
