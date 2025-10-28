using Microsoft.AspNetCore.Mvc;
using Reservation.UI.Interfaces.Services;
using Reservation.UI.Models.DTOs.Request.Room;

namespace Reservation.UI.Controllers;

[Route("roomFeature")]
public class RoomFeatureController : Controller
{
    private readonly IRoomFeatureService _roomFeatureService;

    public RoomFeatureController(IRoomFeatureService roomFeatureService)
    {
        _roomFeatureService = roomFeatureService;
    }
    
    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CreateRoomFeatureRequestDto request)
    {
        await _roomFeatureService.CreateRoomFeature(request);
        return Json(new { success = true });
    }
    
    [HttpPost("update")]
    public async Task<IActionResult> Update([FromBody] UpdateRoomFeatureRequestDto request)
    {
        await _roomFeatureService.UpdateRoomFeature(request);
        return Json(new { success = true });
    }
    
    [HttpPost("remove")]
    public async Task<IActionResult> Remove(int id)
    {
        await _roomFeatureService.RemoveRoomFeature(id);
        return Json(new { success = true });
    }
}