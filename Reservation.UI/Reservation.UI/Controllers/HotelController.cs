using Microsoft.AspNetCore.Mvc;
using Reservation.UI.Interfaces.Services;
using Reservation.UI.Models.DTOs.Request.Hotel;

namespace Reservation.UI.Controllers;

[Route("hotel")]
public class HotelController: Controller
{
    private readonly IHotelService _hotelService;

    public HotelController(IHotelService hotelService)
    {
        _hotelService = hotelService;
    }
    
    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CreateHotelRequestDto request)
    {
        await _hotelService.CreateHotel(request);
        return Json(new { success = true });
    }
}