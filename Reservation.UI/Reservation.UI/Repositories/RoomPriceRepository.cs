using Reservation.UI.Domains;
using Reservation.UI.Interfaces.Repositories;
using Reservation.UI.Models.DTOs.Response.Room;
using Reservation.UI.Repositories.Base;

namespace Reservation.UI.Repositories;

public class RoomPriceRepository : ApiClientBase, IRoomPriceRepository
{
    private readonly string _baseUrl = "http://localhost:5162/";
    
    public RoomPriceRepository(HttpClient httpClient) : base(httpClient) { }

    public async Task<List<RoomPriceResponseDto>?> GetRoomPrices(int roomId)
        => await GetAsync<List<RoomPriceResponseDto>>($"{_baseUrl}api/v1/roomPrice/getAllByHotelId?hotelId={roomId}");

    public async Task CreateRoomPrice(RoomPriceDomain model)
        => await PostAsync<RoomPriceDomain, Task>($"{_baseUrl}api/v1/roomPrice/create", model);

    public async Task UpdateRoomPrice(RoomPriceDomain model)
        => await PostAsync<RoomPriceDomain, Task>($"{_baseUrl}api/v1/roomPrice/update", model);

    public async Task RemoveRoomPrice(int id)
        => await PostAsync<Task, Task>($"{_baseUrl}api/v1/roomPrice/remove?id={id}", null);
}