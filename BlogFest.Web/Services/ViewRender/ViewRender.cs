using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace BlogFest.Web.Services.ViewRender
{
	public interface IViewRenderService
	{
		Task<string> RenderViewToStringAsync(object model);
		Task<string> RenderViewToStringAsync(string viewPath, object model);
	}

	public class ViewRendererService : IViewRenderService
	{
		private readonly IRazorViewEngine _razorViewEngine;
		private readonly ITempDataProvider _tempDataProvider;
		private readonly IActionContextAccessor _actionContextAccessor;

		public ViewRendererService(IRazorViewEngine razorViewEngine,
			ITempDataProvider tempDataProvider,
			IActionContextAccessor actionContextAccessor)
		{
			_razorViewEngine = razorViewEngine;
			_tempDataProvider = tempDataProvider;
			_actionContextAccessor = actionContextAccessor;
		}

		public async Task<string> RenderViewToStringAsync(object model)
		{
			var actionName = _actionContextAccessor.ActionContext.ActionDescriptor.RouteValues["action"];
			return await RenderViewToStringAsync(actionName, model);
		}

		public async Task<string> RenderViewToStringAsync(string viewPath, object model)
		{
			var actionContext = _actionContextAccessor.ActionContext;
			var viewEngineResult = _razorViewEngine.FindView(actionContext, viewPath, false);

			if (viewEngineResult.View == null || (!viewEngineResult.Success))
			{
				throw new ArgumentNullException($"Unable to find view '{viewPath}'");
			}

			var view = viewEngineResult.View;
			var viewDictionary = new ViewDataDictionary(new EmptyModelMetadataProvider(), actionContext.ModelState);
			viewDictionary.Model = model;
			var tempData = new TempDataDictionary(actionContext.HttpContext,
				_tempDataProvider);

			using (var sw = new StringWriter())
			{
				var viewContext = new ViewContext(actionContext, view, viewDictionary, tempData, sw, new HtmlHelperOptions());
				await view.RenderAsync(viewContext);
				return sw.ToString();
			}
		}
	}
}
