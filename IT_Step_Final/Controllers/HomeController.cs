using Microsoft.AspNetCore.Mvc;
using IT_Step_Final.Models;
using Microsoft.AspNetCore.Authorization;
using System.Diagnostics;
using IT_Step_Final.Models;

namespace IT_Step_Final.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [Authorize]
    [AllowAnonymous]
    public IActionResult Index()//intro page
    {
        return View();
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
