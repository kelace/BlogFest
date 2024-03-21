using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BlogFest.Models;

namespace BlogFest.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [Route("/")]
    public IActionResult Index()
    {

        if (!User.Identity.IsAuthenticated)
        {
           return  RedirectToAction("Index", "Authorization");
        }

        return RedirectToAction("MainUserPage", "User");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
