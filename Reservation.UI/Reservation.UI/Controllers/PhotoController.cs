using Microsoft.AspNetCore.Mvc;
using Reservation.UI.Interfaces.Services;
using Reservation.UI.Models.DTOs.Request.Photo;

namespace Reservation.UI.Controllers;

[Route("photo")]
public class PhotoController : Controller
{
    private readonly IPhotoService _photoService;

    public PhotoController(IPhotoService photoService)
    {
        _photoService = photoService;
    }
    
    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CreatePhotoRequestDto request)
    {
        await _photoService.CreatePhoto(request);
        return Json(new { success = true });
    }
    
    [HttpPost("update")]
    public async Task<IActionResult> Update([FromBody] UpdatePhotoRequestDto request)
    {
        await _photoService.UpdatePhoto(request);
        return Json(new { success = true });
    }
    
    [HttpPost("remove")]
    public async Task<IActionResult> Remove(int id)
    {
        await _photoService.RemovePhoto(id);
        return Json(new { success = true });
    }
}