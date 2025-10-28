using Reservation.UI.Domains;
using Reservation.UI.Interfaces.Repositories;
using Reservation.UI.Models.DTOs.Response.Room;
using Reservation.UI.Repositories.Base;

namespace Reservation.UI.Repositories;

public class RoomRepository : ApiClientBase, IRoomRepository
{
    private readonly string _baseUrl = "http://localhost:5162/";
    
    public RoomRepository(HttpClient httpClient) : base(httpClient) { }

    public async Task<List<RoomResponseDto>?> GetHotelRooms(int hotelId)
        => await GetAsync<List<RoomResponseDto>>($"{_baseUrl}api/v1/room/getAllByHotelId?hotelId={hotelId}");

    public async Task CreateRoom(RoomDomain model)
        => await PostAsync<RoomDomain, Task>($"{_baseUrl}api/v1/room/create", model);

    public async Task UpdateRoom(RoomDomain model)
        => await PostAsync<RoomDomain, Task>($"{_baseUrl}api/v1/room/update", model);

    public async Task RemoveRoom(int id)
        => await PostAsync<Task, Task>($"{_baseUrl}api/v1/room/remove?id={id}", null);
    
    public async Task<RoomResponseDto?> GetRoom(int id)
        => await GetAsync<RoomResponseDto>($"{_baseUrl}api/v1/room/getById?id={id}");
}