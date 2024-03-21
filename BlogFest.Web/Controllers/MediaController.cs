using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlogFest.Infrastructure.Persistance;
using BlogFest.Services.UserContext;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Security.Claims;
using BlogFest.Services.FileStorage;
using Microsoft.Extensions.FileProviders;
using BlogFest.Application.Abstract;
using BlogFest.Infrastruction.ImageResizer;

namespace BlogFest.Controllers
{
    public class MediaController : Controller
    {
        private readonly IWebHostEnvironment _environment;
        private readonly IUserContext _userContext;
        private readonly ApplicationDbContext _context;
        private readonly IUserImageLoader _fileProvider;
        private readonly IFileStorageSystem _fileStorage;
        private readonly IImageResizer _imageResizer;

        public MediaController(IWebHostEnvironment environment, IUserContext userContext, ApplicationDbContext context, IImageResizer imageResizer, IFileStorageSystem fileStorage, IUserImageLoader imageLoader)
        {
            _environment = environment;
            _userContext = userContext;
            _context = context;
            _fileStorage = fileStorage;
            _imageResizer = imageResizer;
            _fileProvider = imageLoader;
        }

        // GET: MediaController
        public ActionResult Index()
        {
            return View();
        }

        //[HttpGet]
        //[Route("media/file/{id}")]
        //public async Task<IActionResult> GetMediaFile(Guid Id, [FromQuery]  int? width , [FromQuery] int? height)
        //{

        //    if(Id == Guid.Empty) return File("", "image/png");

        //    var file = await _fileProvider.GetFileAsync(Id);

        //    if(width != null && height != null)
        //    {
        //        file = await _imageResizer.ResizeImageAsync(file, width.GetValueOrDefault(), height.GetValueOrDefault());
        //    }

        //    return File(file, "image/png");

        //}

    }
}
