using Microsoft.AspNetCore.Mvc;
using Reservation.UI.Interfaces.Services;
using Reservation.UI.Models.DTOs.Request.Room;

namespace Reservation.UI.Controllers;

[Route("roomPrice")]
public class RoomPriceController : Controller
{
    private readonly IRoomPriceService _roomPriceService;

    public RoomPriceController(IRoomPriceService roomPriceService)
    {
        _roomPriceService = roomPriceService;
    }
    
    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CreateRoomPriceRequestDto request)
    {
        await _roomPriceService.CreateRoomPrice(request);
        return Json(new { success = true });
    }
    
    [HttpPost("update")]
    public async Task<IActionResult> Update([FromBody] UpdateRoomPriceRequestDto request)
    {
        await _roomPriceService.UpdateRoomPrice(request);
        return Json(new { success = true });
    }
    
    [HttpPost("remove")]
    public async Task<IActionResult> Remove(int id)
    {
        await _roomPriceService.RemoveRoomPrice(id);
        return Json(new { success = true });
    }
}