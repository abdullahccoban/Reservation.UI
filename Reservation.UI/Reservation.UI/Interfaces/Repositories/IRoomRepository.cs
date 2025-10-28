using Reservation.UI.Domains;
using Reservation.UI.Models.DTOs.Response.Room;

namespace Reservation.UI.Interfaces.Repositories;

public interface IRoomRepository
{
    Task<List<RoomResponseDto>?> GetHotelRooms(int hotelId);
    Task CreateRoom(RoomDomain model);
    Task UpdateRoom(RoomDomain model);
    Task RemoveRoom(int id);
    Task<RoomResponseDto?> GetRoom(int id);
}