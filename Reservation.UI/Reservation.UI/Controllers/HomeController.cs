using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reservation.UI.Interfaces.Services;
using Reservation.UI.Models;

namespace Reservation.UI.Controllers;

public class HomeController : Controller
{
    private readonly IHotelService _hotelService;

    public HomeController(IHotelService hotelService)
    {
        _hotelService = hotelService;
    }
    
    public async Task<IActionResult> Index()
    {
        HomeViewModel model = new HomeViewModel()
        {
            HotelCards = await _hotelService.GetHotelCards()
        };
        
        return View(model);
    }
    
    public async Task<IActionResult> Detail(int id)
    {
        var hotelDetail = await _hotelService.GetHotelDetail(id);
        return View(hotelDetail);
    }

    [Authorize(Roles = "User, HotelAdmin")]
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