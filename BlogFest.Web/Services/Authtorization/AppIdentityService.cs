using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;
using BlogFest.Data;
using System.Text;
using BlogFest.Application.Abstract;
using BlogFest.Infrastruction.Authtorization;
using BlogFest.Application.Shared;
using BlogFest.Domain.Base;
using BlogFest.Web.Services.Email;
using Microsoft.AspNetCore.WebUtilities;
using BlogFest.Application.Services.Identity.DTOs;

namespace BlogFest.Web.Services.Identity
{
    public class AppIdentityService : IApplicationAuthentication
    {
        private readonly UserManager<AuthUser> _userManager;
        private readonly SignInManager<AuthUser> _signInManager;
        private readonly IUserContext _userContext;
        private readonly IMemoryCache _memoryCache;
        private readonly LinkGenerator _linkGenerator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IEmailSender _emailSender;
        public AppIdentityService(UserManager<AuthUser> userManager, SignInManager<AuthUser> signInManager, IUserContext userContext, IMemoryCache memoryCache, LinkGenerator linkGenerator, IHttpContextAccessor httpContextAccessor, IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userContext = userContext;
            _memoryCache = memoryCache;
            _linkGenerator = linkGenerator;
            _httpContextAccessor = httpContextAccessor;
            _emailSender = emailSender;
        }

        public async Task<Result<SuccessInfo, List<Error>>> ConfirmEmail(Guid userId, string token)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            if (user == null) new Error("Authentication.ConfirmEmail", "User doesnt exist");

            var result =  await _userManager.ConfirmEmailAsync(user, token);

            if (!result.Succeeded) return MapIdentityErrorToDomainError(result);

            await _signInManager.SignInAsync(user, true);

            return new SuccessInfo
            {
                Message = "User's emal has been confirmed"
            };
        }

        public async Task LogOut()
        {

            var id = _userContext.CurrentUserId;
            await _signInManager.SignOutAsync();

            _memoryCache.Remove(id);
        }

        public async Task<Result<SuccessInfo, List<Error>>> DeleteAuthUserAsync(Guid id)
        {
            var currentUser = _userContext.CurrentUserId;

            if (currentUser != id) return new List<Error>
            {
                new Error("Authentication.Configuration.DeleteUser", "Not allowed to delete somebody else")
            };

            var user = await _userManager.FindByIdAsync(id.ToString());

            var result = await _userManager.DeleteAsync(user);
            
            if (result.Succeeded) return new SuccessInfo
            {
                Id = id
            };

            await _signInManager.SignOutAsync();

            return MapIdentityErrorToDomainError(result);
        }

		public async Task<Result<SuccessInfo, List<Error>>> RegisterUser(RegisterUserDTO model)
		{
			var authUser = new AuthUser
			{
				UserName = model.Name,
				Email = model.Email,
			};

			var result = await _userManager.CreateAsync(authUser, model.Password);

			if (!result.Succeeded)
			{
				return MapIdentityErrorToDomainError(result);
			}

			var userId = await _userManager.GetUserIdAsync(authUser);
			var code = await _userManager.GenerateEmailConfirmationTokenAsync(authUser);

			code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

			var link = _linkGenerator.GetUriByAction(
				_httpContextAccessor.HttpContext,
				"ConfirmEmail",
				"Authorization",
				values: new { userId = userId, code = code },
				 _httpContextAccessor.HttpContext.Request.Scheme);

			var message = $"Follow this link <a href='{link}'>click here</a> to confirm your account";

			await _emailSender.SendEmailAsync(model.Email, "Confirming account", message);

            return new SuccessInfo
            {
                Message = "You have been registred succesfully. Check your email to confirm registration",
                Id = authUser.Id
            };
		}

		public async Task<Result<SuccessInfo, Error>> LoginUser(LoginUserDTO model)
		{
            var user = await _userManager.FindByNameAsync(model.Name);

            if(user == null) return new Error("Authentication.SignIn.UserNotFound", "User name or password is incrorrect");
            if (!user.EmailConfirmed) return new Error("Authentication.SignIn.EmailNotConfirmed", "The email is not confirmed");

            var result = await _signInManager.PasswordSignInAsync(user,
				  model.Password, model.RememberMe, true);

            if (!result.Succeeded) return new Error("Authentication.SignIn", "User name or password is incrorrect");

            return new SuccessInfo
            {
                Id = user.Id
            };
		}

		public async Task<Result<SuccessInfo, List<Error>>> ResetPassword(ResetPasswordDTO model)
		{
			var user = await _userManager.FindByEmailAsync(model.Email);

			var result = await _userManager.ResetPasswordAsync(user, model.Code, model.Password);

            if (!result.Succeeded) return MapIdentityErrorToDomainError(result);

            return new SuccessInfo
            {
                Id = user.Id
            };
		}

		public async Task<Result<SuccessInfo, Error>> RecoveryPassword(RecoveryPasswordDTO model)
		{
			var user = await _userManager.FindByEmailAsync(model.Email);

			if (user != null && user.EmailConfirmed)
			{
				var code = _userManager.GeneratePasswordResetTokenAsync(user);

				var link = _linkGenerator.GetUriByAction(
					_httpContextAccessor.HttpContext,
					"ResetPassword",
					"Authorization",
					values: new { email = user.Email, code = code.Result },
					 _httpContextAccessor.HttpContext.Request.Scheme);

				var message = $"Click <a href={link}>here</a> for password recovery";

				await _emailSender.SendEmailAsync(user.Email, "Password Recovery", message);

                return new SuccessInfo { Id = user.Id, Message = "Email with verification token has been sent" };
			}

            return new Error("Authentication.Recovery", "User doesnt exist");
		}

		private List<Error> MapIdentityErrorToDomainError(IdentityResult result)
        {
            return result.Errors.Select(x => new Error(x.Code, x.Description)).ToList();
        }
	}
}
