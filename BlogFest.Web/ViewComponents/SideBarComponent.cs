using BlogFest.Infrastructure.Persistance;
using BlogFest.Web.ViewModels.Administration;
using BlogFest.Web.ViewModels.Content;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogFest.Web.ViewComponents
{
	public class SideBarViewComponent : ViewComponent
	{
		private readonly ApplicationDbContext _db;
		public SideBarViewComponent(ApplicationDbContext db)
		{
			_db = db;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var result = await _db.Categories.Where(x => x.Enabled).Select(x => new CategorySideBarViewModel
            {
				Id = x.Id,
				Title = x.Title,
				Enabled = x.Enabled,
				EncodedTitle = x.EncodedTitle,
				Count = _db.CategoriesPosts.Where(p => p.CategoryId == x.Id).Count()
			}).ToListAsync();

			return View(result);
		}
	}
}
