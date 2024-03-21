using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BlogFest.Infrastructure.Persistance;
using BlogFest.Infrastructure.Persistance.DataModels;
using BlogFest.Models.Configuration;
using BlogFest.Services.UserContext;
using BlogFest.Web.Infrastructure.Extensions;
using BlogFest.Web.ViewModels.User;
using BlogFest.Application.Configuration.Commands.UploadUserImage;
using BlogFest.Web.ViewModels.Configuration;
using BlogFest.Domain.Base;
using BlogFest.Web.Filters;
using BlogFest.Application.Services.Configuration.Queries.GetConfigurationInfo;
using BlogFest.Application.Abstract;
using BlogFest.Application.Services.Configuration.Queries.DTOs;
using BlogFest.Application.Services.Configuration.Commands.EditUserInformation;
using BlogFest.Application.Services.Configuration.Commands.DeleteUser;
using Microsoft.AspNetCore.Routing;
using BlogFest.Application.Services.Configuration.Commands.RemoveUserPhoto;
using System.ComponentModel.DataAnnotations;

namespace BlogFest.Controllers
{
    [Authorize]
    [Route("user/configuration")]
    public class ConfigurationController : Controller
    {
        private readonly IWebHostEnvironment _environment;
        private readonly IUserContext _userContext;
        private readonly ApplicationDbContext _context;
        private readonly IMediator _mediator;
        private readonly LinkGenerator _linkGenerator;
        public ConfigurationController(LinkGenerator linkGenerator,IWebHostEnvironment environment, IUserContext userContext, ApplicationDbContext context, IMediator mediator)
        {
            _environment = environment;
            _userContext = userContext;
            _context = context;
            _mediator = mediator;
            _linkGenerator = linkGenerator;
        }

        public async Task<ActionResult> Index()
        {
            var uid = _userContext.CurrentUserId;

            var model = await _mediator.Send<UserConfigurationDto>(new GetConfigurationInfoQuery
            {
                UserId = _userContext.CurrentUserId
            });

            return View(model);
        }

        [Route("image")]
        [HttpPost]
        [DefaultValidateModel]

        public async Task<IActionResult> UploadUserImage(UploadUserImageViewModel model)
        {

            var result = await _mediator.Send<Result<(Guid, Guid, string), Error>>(new UploadUserImageCommand
            {
                Photo = await model.FileToArray()
            });

            return result.Match<IActionResult>(x => Json(new { result = true, imageUserId = x.Item2, imageFileId = x.Item1, imageUrl = "/media/" + x.Item3 }), x => Json(new {result = false, htmlError = x.Description}));
        }

        [Route("")]
        [HttpPut]
        [DefaultValidateModelAttribute]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUserInformation(EditUserInformationViewModel model)
        {

            await _mediator.Send(new EditUserInformationCommand
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhotoId = model.PhotoId,
                Bio = model.Bio
            });

            return Ok(new
            {
                data = "Information has been edited successfully"
            });
        }

        [HttpDelete]
        [Route("")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var result = await _mediator.Send<Result<SuccessInfo, List<Error>>>(new DeleteUserCommand
            {
                Id= id
            });

            return result.Match<IActionResult>(x => Json(new { result = true, message = "User Succesfully has been deleted", urlRedirect = _linkGenerator.GetPathByAction("Login", "Authtorization") }), x => Json(new { result = false, message = "Error occured while atempt to delte user", errors = x}));
        }

        [HttpDelete]
        [DefaultValidateModel]
        [Route("image")]
        public async Task<IActionResult> RemoveUserPhoto(Guid id)
        {
            var result = await _mediator.Send<Result<SuccessInfo, Error>>(new RemoveUserPhotoCommand
            {
                PhotoFileId = id
            });

            return result.Match<IActionResult>(x => Json(new { result = true }), x => Json(new { result = false, message = x.Description}));
        }
    }
}
