using Reservation.UI.Domains;
using Reservation.UI.Interfaces.Repositories;
using Reservation.UI.Interfaces.Services;
using Reservation.UI.Models.DTOs.Request.Favorite;
using Reservation.UI.Models.DTOs.Response.Favorite;

namespace Reservation.UI.Services;

public class FavoriteService : IFavoriteService
{
    private readonly IFavoriteRepository _favoriteRepository;

    public FavoriteService(IFavoriteRepository favoriteRepository)
    {
        _favoriteRepository = favoriteRepository;
    }

    public async Task AddFavorite(AddFavoriteRequestDto request)
    {
        var domain = new FavoriteDomain(request.HotelId, request.UserId);
        await _favoriteRepository.AddFavorite(domain);
    }

    public async Task RemoveFavorite(RemoveFavoriteRequestDto request)
    {
        var domain = new FavoriteDomain(request.HotelId, request.UserId);
        await _favoriteRepository.RemoveFavorite(domain);
    }

    public async Task<List<FavoriteResponseDto>?> GetFavorites(string userId)
        => await _favoriteRepository.GetFavorites(userId);
}