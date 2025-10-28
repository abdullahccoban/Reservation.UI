using Reservation.UI.Domains;
using Reservation.UI.Interfaces.Repositories;
using Reservation.UI.Interfaces.Services;
using Reservation.UI.Models.DTOs.Request.Room;
using Reservation.UI.Models.DTOs.Response.Room;

namespace Reservation.UI.Services;

public class RoomService : IRoomService
{
    private readonly IRoomRepository _repo;

    public RoomService(IRoomRepository repo)
    {
        _repo = repo;
    }

    public async Task<List<RoomResponseDto>?> GetAllRooms(int hotelId)
        => await _repo.GetHotelRooms(hotelId);

    public async Task CreateRoom(CreateRoomRequestDto request)
    {
        var domain = new RoomDomain(request.HotelId, request.RoomType, request.Capacity, request.Count);
        await _repo.CreateRoom(domain);
    }

    public async Task UpdateRoom(UpdateRoomRequestDto request)
    {
        var domain = new RoomDomain(request.HotelId, request.RoomType, request.Capacity, request.Count, request.Id);
        await _repo.UpdateRoom(domain);
    }

    public async Task RemoveRoom(int id)
        => await _repo.RemoveRoom(id);
}