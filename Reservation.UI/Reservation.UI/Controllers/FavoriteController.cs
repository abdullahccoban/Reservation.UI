using Microsoft.AspNetCore.Mvc;
using Reservation.UI.Interfaces.Services;
using Reservation.UI.Models.DTOs.Request.Favorite;

namespace Reservation.UI.Controllers;

[Route("favorite")]
public class FavoriteController : Controller
{
    private readonly IFavoriteService _favoriteService;

    public FavoriteController(IFavoriteService favoriteService)
    {
        _favoriteService = favoriteService;
    }

    [HttpPost("add")]
    public async Task<IActionResult> AddFavorite([FromBody] AddFavoriteRequestDto request)
    {
        request.UserId = User!.Claims!.FirstOrDefault(i => i.Type == "email")!.Value;
        await _favoriteService.AddFavorite(request);
        return Ok();
    }

    [HttpPost("remove")]
    public async Task<IActionResult> AnswerQuestion([FromBody] RemoveFavoriteRequestDto request)
    {
        request.UserId = User!.Claims!.FirstOrDefault(i => i.Type == "email")!.Value;
        await _favoriteService.RemoveFavorite(request);
        return Ok();
    }
}