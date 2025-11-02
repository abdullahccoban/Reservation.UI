using Microsoft.AspNetCore.Mvc;
using Reservation.UI.Interfaces.Services;
using Reservation.UI.Models.DTOs.Request.HotelAdmin;

namespace Reservation.UI.Controllers;

[Route("hotelAdmin")]
public class HotelAdminController : Controller
{
    private readonly IHotelAdminService _adminService;

    public HotelAdminController(IHotelAdminService infoService)
    {
        _adminService = infoService;
    }
    
    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CreateHotelAdminRequestDto request)
    {
        await _adminService.CreateHotelAdmin(request);
        return Json(new { success = true });
    }
    
    [HttpPost("update")]
    public async Task<IActionResult> Update([FromBody] UpdateHotelAdminRequestDto request)
    {
        await _adminService.UpdateHotelAdmin(request);
        return Json(new { success = true });
    }
    
    [HttpPost("remove")]
    public async Task<IActionResult> Remove(int id)
    {
        await _adminService.RemoveHotelAdmin(id);
        return Json(new { success = true });
    }
}