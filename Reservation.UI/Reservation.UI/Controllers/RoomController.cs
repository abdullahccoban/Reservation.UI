using Microsoft.AspNetCore.Mvc;
using Reservation.UI.Interfaces.Services;
using Reservation.UI.Models.DTOs.Request.Room;

namespace Reservation.UI.Controllers;

[Route("room")]
public class RoomController : Controller
{
    private readonly IRoomService _roomService;

    public RoomController(IRoomService roomService)
    {
        _roomService = roomService;
    }
    
    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CreateRoomRequestDto request)
    {
        await _roomService.CreateRoom(request);
        return Json(new { success = true });
    }
    
    [HttpPost("update")]
    public async Task<IActionResult> Update([FromBody] UpdateRoomRequestDto request)
    {
        await _roomService.UpdateRoom(request);
        return Json(new { success = true });
    }
    
    [HttpPost("remove")]
    public async Task<IActionResult> Remove(int id)
    {
        await _roomService.RemoveRoom(id);
        return Json(new { success = true });
    }
}