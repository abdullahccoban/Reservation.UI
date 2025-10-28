using Reservation.UI.Domains;
using Reservation.UI.Interfaces.Repositories;
using Reservation.UI.Models.DTOs.Response.Room;
using Reservation.UI.Repositories.Base;

namespace Reservation.UI.Repositories;

public class RoomFeatureRepository : ApiClientBase, IRoomFeatureRepository
{
    private readonly string _baseUrl = "http://localhost:5162/";
    
    public RoomFeatureRepository(HttpClient httpClient) : base(httpClient) { }

    public async Task<List<RoomFeatureResponseDto>?> GetRoomFeatures(int roomId)
        => await GetAsync<List<RoomFeatureResponseDto>>($"{_baseUrl}api/v1/roomFeature/getAllByHotelId?hotelId={roomId}");

    public async Task CreateRoomFeature(RoomFeatureDomain model)
        => await PostAsync<RoomFeatureDomain, Task>($"{_baseUrl}api/v1/roomFeature/create", model);

    public async Task UpdateRoomFeature(RoomFeatureDomain model)
        => await PostAsync<RoomFeatureDomain, Task>($"{_baseUrl}api/v1/roomFeature/update", model);

    public async Task RemoveRoomFeature(int id)
        => await PostAsync<Task, Task>($"{_baseUrl}api/v1/roomFeature/remove?id={id}", null);
}