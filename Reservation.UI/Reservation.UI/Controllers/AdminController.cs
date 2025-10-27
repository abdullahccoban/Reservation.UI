using Microsoft.AspNetCore.Mvc;
using Reservation.UI.Interfaces.Services;
using Reservation.UI.Models;

namespace Reservation.UI.Controllers;

public class AdminController : Controller
{
    private readonly IHotelInformationService _infoService;

    public AdminController(IHotelInformationService infoService)
    {
        _infoService = infoService;
    }
    
    public IActionResult Index()
    {
        return View();
    }
    
    [Route("Admin/Hotel/{hotelId:int}")]
    public async Task<IActionResult> Hotel(int hotelId)
    {
        AdminViewModel model = new AdminViewModel
        {
            HotelId = hotelId,
            HotelInfos = await _infoService.GetAllHotelInfos(hotelId)
        };
        return View(model);
    }
    
    public IActionResult Photo()
    {
        return View();
    }
    
    public IActionResult Promotion()
    {
        return View();
    }
    
    public IActionResult Price()
    {
        return View();
    }
    
    public IActionResult Reservation()
    {
        return View();
    }
    
    public IActionResult Room()
    {
        return View();
    }
    
    public IActionResult QA()
    {
        return View();
    }
    
    public IActionResult Tag()
    {
        return View();
    }
}