using Reservation.UI.Domains;
using Reservation.UI.Models.DTOs.Response.Favorite;

namespace Reservation.UI.Interfaces.Repositories;

public interface IFavoriteRepository
{
    Task AddFavorite(FavoriteDomain model);
    Task RemoveFavorite(FavoriteDomain model);
    Task<List<FavoriteResponseDto>?> GetFavorites(string userId);
}