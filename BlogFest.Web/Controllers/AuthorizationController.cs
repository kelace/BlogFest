using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using BlogFest.Infrastructure.Persistance;
using BlogFest.Models.Authorization;
using BlogFest.Web.Infrastructure.Extensions;
using BlogFest.Web.Services.Identity;
using BlogFest.Web.ViewModels.Authorization;
using System.Text;
using BlogFest.Application.Abstract;
using BlogFest.Infrastruction.Authtorization;
using BlogFest.Web.Filters;
using MediatR;
using BlogFest.Domain.Base;
using BlogFest.Application.Services.Identity.Commands.CreateUser;
using AutoMapper;
using BlogFest.Application.Services.Identity.DTOs;
using BlogFest.Application.Shared;
using BlogFest.Web.Extensions;
using Microsoft.AspNetCore.Routing;

namespace BlogFest.Controllers
{
    [Route("/authorization")]
    public class AuthorizationController : Controller
    {
        private readonly IApplicationAuthentication _identityService;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IUserContext _userContext;
        private readonly LinkGenerator _linkGenerator;
        public AuthorizationController(IApplicationAuthentication identityService, IUserContext userContext, IMediator mediator, IMapper mapper, LinkGenerator linkGenerator)
        {
            _identityService = identityService;
            _userContext = userContext;
            _mediator = mediator;
			_mapper = mapper;
            _linkGenerator = linkGenerator;
        }

        [Route("signin")]
        public ActionResult Index()
        {
            if (_userContext.IsAuthenticated) return RedirectToAction("MainUserPage", "User");
            return View();
        }

        [Route("register")]
        public ActionResult RegisterUser()
        {
            if (_userContext.IsAuthenticated) return RedirectToAction("MainUserPage", "User");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("signin")]
        public async Task<IActionResult> SignIn(LoginUserViewModel model)
        {
            if (_userContext.IsAuthenticated)
            {
                Json(new { result = false, message = "User already authenticated" });
            }

            if (!ModelState.IsValid)
            {
                Response.StatusCode = 400;
                return Json(new {result = false ,message = "Data is invalid", htmlResult = await this.RenderViewAsync<LoginUserViewModel>("_PartialSignIn", model, true) });
            }

            var dto = _mapper.Map<LoginUserDTO>(model);
            var result =  await _identityService.LoginUser(dto);

            return await result.Match<Task<IActionResult>>(async x=> Json(new {result = true, linkRedirect = _linkGenerator.GetPathByAction("MainUserPage", "User") }) , async x =>
            {
                ModelState.AddModelError(string.Empty, x.Description);
                return Json(new { result = false, message = x.Description, htmlResult = await this.RenderViewAsync<LoginUserViewModel>("_PartialSignIn", model, true) });
			});
        }

        [HttpPost]
        [Route("password-reset")]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            var dto = _mapper.Map<ResetPasswordDTO>(model);
            var result = await _identityService.ResetPassword(dto);

            return await result.Match<Task<IActionResult>>(async x => Json(new { result = true, linkRedirect = _linkGenerator.GetPathByAction("Index", "Authorization") }), async x =>
            {

                foreach (var item in result.Error)
                {
                    ModelState.AddModelError(string.Empty, item.Description);
                }

                return Json(new { result = false, htmlResult = await this.RenderViewAsync("_PartialReset", model, true)});
            });
        }

        [HttpGet]
        [Route("password-reset")]
        public async Task<IActionResult> ResetPassword(string email, string code)
        {
            return View();
        }

        [HttpPost]
        [Route("password-recovery")]
        public async Task<IActionResult> RecoveryPassword(RecoveryPasswordViewModel model)
        {
			var dto = _mapper.Map<RecoveryPasswordDTO>(model);

			var result = await _identityService.RecoveryPassword(dto);

            return await result.Match<Task<IActionResult>>(async x => Json(new { result = true, message = x.Message, linkRedirect = _linkGenerator.GetPathByAction("SignIn", "Authorization") }), async x =>
            {
                ModelState.AddModelError(string.Empty, x.Description);
                return Json(new { result = false, htmlResult = await this.RenderViewAsync("_PartialRecovery", model, true) });
            });
        }

        [HttpGet]
        [Route("password-recovery")]
        public async Task<IActionResult> RecoveryPassword()
        {
            return View();
        }

        [HttpGet]
        [Route("confirm-email")]
        public async Task<IActionResult> ConfirmEmail(Guid userId, string code)
        {
            var s = Encoding.UTF8.GetBytes(code);
            var s2 = System.Text.Encoding.UTF8.GetString(s);

            var bts  = WebEncoders.Base64UrlDecode(code);
            var token = Encoding.UTF8.GetString(bts);
            var result = await _identityService.ConfirmEmail(userId, token);
            return result.Match<IActionResult>( x => RedirectToAction("MainUserPage", "User"),  x => Json(new { result = true, errors = x }));
        }

        [HttpPost]
        [DefaultValidateModel]
        [ValidateAntiForgeryToken]
        [Route("register")]
        public async Task<IActionResult> RegisterUser(RegisterUserViewModel model)
        {

            var result = await _mediator.Send<Result<SuccessInfo, List<Error>>>(new CreateUserCommand
            {
                RegisterUser = _mapper.Map<RegisterUserDTO>(model)
			});

            return await result.Match<Task<IActionResult>>(async x => Json(new { result = true, message = x.Message, linkRedirect = _linkGenerator.GetPathByAction("SignIn", "Authorization") }), async x =>
            {
                AttachIdentityResultToModel(x, model);
                return Json(new { result = false, htmlResult = await this.RenderViewAsync<RegisterUserViewModel>("_PartialSignUp", model, true) });
            });
        }

        public async Task<IActionResult> LogOut()
        {
            await _identityService.LogOut();
            return RedirectToAction("Index", "Home");
        }

		private void AttachIdentityResultToModel(List<Error> result, RegisterUserViewModel model)
		{
			foreach (var error in result)
			{
				if (error.Code == "DuplicateUserName")
				{
					ModelState.AddModelError(nameof(model.Name), error.Description);
				}		
                var n = nameof(RegisterUserViewModel.Email);

                if (error.Code == "PasswordMismatch")
				{
					ModelState.AddModelError(nameof(model.Password), error.Description);
				}

				if (error.Code == "LoginAlreadyAssociated")
				{
					ModelState.AddModelError(nameof(model.Name), error.Description);
				}

				if (error.Code == "InvalidUserName")
				{
					ModelState.AddModelError(nameof(model.Name), error.Description);
				}

				if (error.Code == "DuplicateEmail")
				{
					ModelState.AddModelError(nameof(string.Empty), error.Description);
				}

				if (error.Code == "InvalidRoleName")
				{
					ModelState.AddModelError(nameof(string.Empty), error.Description);
				}

				if (error.Code == "DuplicateRoleName")
				{
					ModelState.AddModelError(nameof(string.Empty), error.Description);
				}

				if (error.Code == "UserAlreadyHasPassword")
				{
					ModelState.AddModelError(nameof(model.Name), error.Description);
				}

				if (error.Code == "UserAlreadyInRole")
				{
					ModelState.AddModelError(nameof(model.Name), error.Description);
				}

				if (error.Code == "PasswordTooShort")
				{
					ModelState.AddModelError(nameof(string.Empty), error.Description);
				}

				if (error.Code == "PasswordRequiresNonAlphanumeric")
				{
					ModelState.AddModelError(nameof(string.Empty), error.Description);
				}

				if (error.Code == "PasswordRequiresDigit")
				{
					ModelState.AddModelError(nameof(string.Empty), error.Description);
				}

				if (error.Code == "PasswordRequiresLower")
				{
					ModelState.AddModelError(nameof(string.Empty), error.Description);
				}

				if (error.Code == "PasswordRequiresUpper")
				{
					ModelState.AddModelError(nameof(string.Empty), error.Description);
				}
			}
		}
	}
}
