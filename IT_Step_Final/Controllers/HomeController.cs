using Microsoft.AspNetCore.Mvc;
using IT_Step_Final.Models;
using Microsoft.AspNetCore.Authorization;
using System.Diagnostics;
using IT_Step_Final.Models;
using OnlineStore.Core.Interfaces;
using OnlineBooking.Domain.Interfaces;
using OnlineBooking.Domain.Dtos;

namespace IT_Step_Final.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IbookingRelate _bookingRelatedServices;
    private readonly IroomRelatedServices _roomRelatedServices;

    public HomeController(ILogger<HomeController> logger, IbookingRelate bookingRelatedServices)
    {
        _logger = logger;
        _bookingRelatedServices = bookingRelatedServices;
    }

    [Authorize]
    [AllowAnonymous]
    public async Task<IActionResult> Index()//intro page
    {
        try
        {
            var res = await _bookingRelatedServices.GetAllAsync(new HotelModel() { Address = "", City = "", Name = "", PicturePath = "" });
            return View(res);
        }
        catch
        {
            return View(new List<HotelModel>());
        }

    }
    [HttpGet]
    public async Task<IActionResult> Search(string query)
    {
        var hotels = await _bookingRelatedServices.GetAllAsync(new HotelModel() { Address = "", City = "", Name = "", PicturePath = "" });
        if (!string.IsNullOrEmpty(query))
        {
            hotels = hotels.Where(h => h.Name.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                          h.City.Contains(query, StringComparison.OrdinalIgnoreCase)).ToList();
        }
        return View("Index",hotels);
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
