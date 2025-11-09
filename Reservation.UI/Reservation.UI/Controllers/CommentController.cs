using Microsoft.AspNetCore.Mvc;
using Reservation.UI.Interfaces.Services;

namespace Reservation.UI.Controllers;

[Route("comment")]
public class CommentController : Controller
{
    private readonly ICommentService _commentService;

    public CommentController(ICommentService commentService)
    {
        _commentService = commentService;
    }
    
    [HttpGet("getHotelComments")]
    public async Task<IActionResult> GetHotelComments(int hotelId)
    {
        var comments = await _commentService.GetHotelComments(hotelId);
        return Ok(comments);
    }
}