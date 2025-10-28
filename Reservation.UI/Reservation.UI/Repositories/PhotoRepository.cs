using Reservation.UI.Domains;
using Reservation.UI.Interfaces.Repositories;
using Reservation.UI.Models.DTOs.Response.Photo;
using Reservation.UI.Repositories.Base;

namespace Reservation.UI.Repositories;

public class PhotoRepository : ApiClientBase, IPhotoRepository
{
    private readonly string _baseUrl = "http://localhost:5162/";
    
    public PhotoRepository(HttpClient httpClient) : base(httpClient) { }

    public async Task<List<PhotoResponseDto>?> GetHotelPhotos(int hotelId)
        => await GetAsync<List<PhotoResponseDto>>($"{_baseUrl}api/v1/photo/getAllByHotelId?hotelId={hotelId}");

    public async Task CreatePhoto(PhotoDomain model)
        => await PostAsync<PhotoDomain, Task>($"{_baseUrl}api/v1/photo/create", model);

    public async Task UpdatePhoto(PhotoDomain model)
        => await PostAsync<PhotoDomain, Task>($"{_baseUrl}api/v1/photo/update", model);

    public async Task RemovePhoto(int id)
        => await PostAsync<Task, Task>($"{_baseUrl}api/v1/photo/remove?id={id}", null);
}