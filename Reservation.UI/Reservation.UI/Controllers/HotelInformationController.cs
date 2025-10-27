using Microsoft.AspNetCore.Mvc;
using Reservation.UI.Interfaces.Services;
using Reservation.UI.Models.DTOs.Request.HotelInformation;

namespace Reservation.UI.Controllers;

[Route("hotelInfo")]
public class HotelInformationController : Controller
{
    private readonly IHotelInformationService _infoService;

    public HotelInformationController(IHotelInformationService infoService)
    {
        _infoService = infoService;
    }
    
    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CreateHotelInformationRequestDto request)
    {
        await _infoService.CreateHotelInfo(request);
        return Json(new { success = true });
    }
    
    [HttpPost("update")]
    public async Task<IActionResult> Update([FromBody] UpdateHotelInformationRequestDto request)
    {
        await _infoService.UpdateHotelInfo(request);
        return Json(new { success = true });
    }
    
    [HttpPost("remove")]
    public async Task<IActionResult> Remove(int id)
    {
        await _infoService.RemoveHotelInfo(id);
        return Json(new { success = true });
    }
}