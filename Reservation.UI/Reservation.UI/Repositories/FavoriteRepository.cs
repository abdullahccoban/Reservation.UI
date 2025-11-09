using Reservation.UI.Domains;
using Reservation.UI.Interfaces.Repositories;
using Reservation.UI.Models.DTOs.Response.Favorite;
using Reservation.UI.Repositories.Base;

namespace Reservation.UI.Repositories;

public class FavoriteRepository : ApiClientBase, IFavoriteRepository
{
    private readonly string _baseUrl = "http://localhost:5162/";
    
    public FavoriteRepository(HttpClient httpClient) : base(httpClient) { }
    
    public async Task AddFavorite(FavoriteDomain model)
        => await PostAsync<FavoriteDomain, Task>($"{_baseUrl}api/v1/favorite/add", model);

    public async Task RemoveFavorite(FavoriteDomain model)
        => await PostAsync<FavoriteDomain, Task>($"{_baseUrl}api/v1/favorite/remove", model);
    
    public async Task<List<FavoriteResponseDto>?> GetFavorites(string userId)
        => await GetAsync<List<FavoriteResponseDto>>($"{_baseUrl}api/v1/favorite/getFavorites?userId={userId}");
}