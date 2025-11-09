using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reservation.UI.Interfaces.Services;
using Reservation.UI.Models;

namespace Reservation.UI.Controllers;

public class HomeController : Controller
{
    private readonly IHotelService _hotelService;
    private readonly IFavoriteService _favoriteService;

    public HomeController(IHotelService hotelService, IFavoriteService favoriteService)
    {
        _hotelService = hotelService;
        _favoriteService = favoriteService;
    }
    
    public async Task<IActionResult> Index()
    {
        string? userId = User.Identity.IsAuthenticated 
            ? User.Claims.FirstOrDefault(i => i.Type == "email")?.Value
            : null;
        
        HomeViewModel model = new HomeViewModel()
        {
            HotelCards = await _hotelService.GetHotelCards(userId)
        };
        
        return View(model);
    }
    
    public async Task<IActionResult> Detail(int id)
    {
        string? userId = User.Identity.IsAuthenticated 
            ? User.Claims.FirstOrDefault(i => i.Type == "email")?.Value
            : null;
        
        var hotelDetail = await _hotelService.GetHotelDetail(id, userId);
        return View(hotelDetail);
    }
    
    [Authorize(Roles = "User, HotelAdmin, SuperAdmin")]
    public async Task<IActionResult> Favorites()
    {
        string userId = User.Claims.FirstOrDefault(i => i.Type == "email")!.Value;
        var favorites = await _favoriteService.GetFavorites(userId);
        return View(favorites);
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