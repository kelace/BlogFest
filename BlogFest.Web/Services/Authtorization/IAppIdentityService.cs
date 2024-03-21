using Microsoft.AspNetCore.Identity;
using BlogFest.Models.Authorization;
using BlogFest.Web.ViewModels.Authorization;

namespace BlogFest.Web.Services.Identity
{
    public interface IAppIdentityService
    {
        Task<IdentityResult> RegisterUserAsync(RegisterUserViewModel model);
        Task LogOut();
        Task ConfirmEmail(Guid userId, string token);
        Task RecoveryPassword(RecoveryPasswordViewModel model);
        Task ResetPassword(ResetPasswordViewModel model);
    }
}