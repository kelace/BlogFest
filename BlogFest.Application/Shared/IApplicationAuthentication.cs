using BlogFest.Application.Services.Identity.DTOs;
using BlogFest.Domain.Base;


namespace BlogFest.Application.Shared
{
    public interface IApplicationAuthentication
    {
        Task LogOut();
        Task<Result<SuccessInfo, List<Error>> > ConfirmEmail(Guid userId, string token);
        Task<Result<SuccessInfo, List<Error>>> DeleteAuthUserAsync(Guid id);
		Task<Result<SuccessInfo, List<Error>>> RegisterUser(RegisterUserDTO model); 
        Task<Result<SuccessInfo, Error>> LoginUser(LoginUserDTO model);
		Task<Result<SuccessInfo, List<Error>>> ResetPassword(ResetPasswordDTO model); 
        Task<Result<SuccessInfo, Error>> RecoveryPassword(RecoveryPasswordDTO model); 
    }
}
