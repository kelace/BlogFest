using BlogFest.Web.Extensions;
using BlogFest.Web.Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using BlogFest.Web.ViewModels;

namespace BlogFest.Web.Filters
{
	public class DefaultValidateModelAttribute : ActionFilterAttribute
	{
		public async override void OnActionExecuting(ActionExecutingContext context)
		{
			if (!context.ModelState.IsValid)
			{
				var errors = context.ModelState.Errors();
				var controller = (Controller) context.Controller;
				var htmlResult = await controller.RenderViewAsync<List<ErrorItemViewModel>>("_ErrorList", errors.Select(x => new ErrorItemViewModel { Key = x.Key, Message = x.Value.ToList() }).ToList(), true);
				context.Result =  new BadRequestObjectResult(new { result = false, errors = errors, htmlError = htmlResult });
				return;
			}
		}
	}
}
