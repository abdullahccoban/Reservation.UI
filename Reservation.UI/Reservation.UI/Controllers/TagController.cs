using Microsoft.AspNetCore.Mvc;
using Reservation.UI.Interfaces.Services;
using Reservation.UI.Models.DTOs.Request.Tag;

namespace Reservation.UI.Controllers;

[Route("tag")]
public class TagController : Controller
{
    private readonly ITagService _tagService;

    public TagController(ITagService tagService)
    {
        _tagService = tagService;
    }
    
    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CreateTagRequestDto request)
    {
        await _tagService.CreateTag(request);
        return Json(new { success = true });
    }
    
    [HttpPost("update")]
    public async Task<IActionResult> Update([FromBody] UpdateTagRequestDto request)
    {
        await _tagService.UpdateTag(request);
        return Json(new { success = true });
    }
    
    [HttpPost("remove")]
    public async Task<IActionResult> Remove(int id)
    {
        await _tagService.RemoveTag(id);
        return Json(new { success = true });
    }
}