using Reservation.UI.Domains;
using Reservation.UI.Interfaces.Repositories;
using Reservation.UI.Models.DTOs.Response.Tag;
using Reservation.UI.Repositories.Base;

namespace Reservation.UI.Repositories;

public class TagRepository : ApiClientBase, ITagRepository
{
    private readonly string _baseUrl = "http://localhost:5162/";
    
    public TagRepository(HttpClient httpClient) : base(httpClient) { }

    public async Task<List<TagResponseDto>?> GetHotelTags(int hotelId)
        => await GetAsync<List<TagResponseDto>>($"{_baseUrl}api/v1/tag/getAllByHotelId?hotelId={hotelId}");

    public async Task CreateTag(TagDomain model)
        => await PostAsync<TagDomain, Task>($"{_baseUrl}api/v1/tag/create", model);

    public async Task UpdateTag(TagDomain model)
        => await PostAsync<TagDomain, Task>($"{_baseUrl}api/v1/tag/update", model);

    public async Task RemoveTag(int id)
        => await PostAsync<Task, Task>($"{_baseUrl}api/v1/tag/remove?id={id}", null);
}