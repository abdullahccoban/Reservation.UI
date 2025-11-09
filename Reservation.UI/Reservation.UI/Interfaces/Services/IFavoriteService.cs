using Reservation.UI.Models.DTOs.Request.Favorite;
using Reservation.UI.Models.DTOs.Response.Favorite;

namespace Reservation.UI.Interfaces.Services;

public interface IFavoriteService
{
    Task AddFavorite(AddFavoriteRequestDto request);
    Task RemoveFavorite(RemoveFavoriteRequestDto request);
    Task<List<FavoriteResponseDto>?> GetFavorites(string userId);
}