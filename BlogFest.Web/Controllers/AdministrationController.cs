using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BlogFest.Domain.Administration;
using BlogFest.Web.ViewModels.Administration;
using BlogFest.Application.Services.Administration.Queries.DTOs;
using MediatR;
using BlogFest.Domain.Base;
using BlogFest.Application.Services.Administration.Commands.EditUser;
using BlogFest.Application.Services.Administration.Commands.AddCategories;
using BlogFest.Application.Services.Administration.Commands.DeleteCategory;
using BlogFest.Web.Filters;
using BlogFest.Application.Services.Administration.Queries.GetAllGategories;
using BlogFest.Application.Services.Administration.Queries.GetAllUsers;

namespace BlogFest.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("/admin")]
    public class AdministrationController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public AdministrationController(IMapper mapper, IMediator mediator)
        {

            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPut]
        [Route("users")]
        public async Task<IActionResult> EditUsers(UsersViewModel model)
        {
            var userSetting = model.Users.Select(x => new UserSettings {UserId = x.Id, IsActive = x.IsActived, IsAllowedToComment = x.IsCommentAllowed, IsAllowedToCreateThread = x.IsCreatePostAllowed }).ToList();

            var result = await _mediator.Send<Result<SuccessInfo, Error>>(new EditUserCommand
            {
                UserSettings = userSetting,
            });

            return result.Match<IActionResult>(x => Json(new { result = true, message = "User edited succesfully" }), x => Json(new { result = false, message = x.Description }));
        }

        [HttpPost]
        [Route("categories")]
        public async Task<IActionResult> AddOrEditCategories(List<CategoryViewModel> Model)
        {
            var categories = _mapper.Map<List<CategoryViewModel>, List<CategoryDTO>>(Model);
            var result = await _mediator.Send<Result<SuccessInfo, Error>>(new AddOrUpdateCategoriesCommand
            {
                Categories = categories
            });

            return Json(new {res = true});  
        }

        [HttpGet]
        [Route("categories")]
        public async Task<IActionResult> Categories()
        {
       
            var categories = await _mediator.Send<List<CategoryDTO>>(new GetAllCategoriesQuery());

            ViewData["Tab"] = "Categories";
            
            var model = _mapper.Map<List<CategoryDTO>, List<CategoryViewModel>>(categories);

            return View(model);
        }

        [HttpGet]
        [Route("users")]
        public async Task<IActionResult> Index()
        {

            var result = await _mediator.Send<List<AdminUserForEditDTO>>(new GetAllUsersQuery());

            var users = _mapper.Map<List<AdminUserForEditDTO>, List<UserViewModel>>(result);

            var model = new UsersViewModel
            {
                Users = users
            };

            ViewData["Tab"] = "Users";

            return View("Users", model);
        }

        [HttpDelete]
        [Route("categories")]
        [DefaultValidateModel]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {

            var result = await _mediator.Send<Result<SuccessInfo, Error>>(new DeleteCategoryCommand
            {
                Id = id
            });

            return result.Match<IActionResult>(x =>  Json(new {result = true, message = "Category has been deleted"}), x => Json(new { result = false, message = x.Description}) );
        }
    }
}
