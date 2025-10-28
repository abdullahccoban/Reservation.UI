using Reservation.UI.Models.DTOs.Request.Room;
using Reservation.UI.Models.DTOs.Response.Room;

namespace Reservation.UI.Interfaces.Services;

public interface IRoomService
{
    Task<List<RoomResponseDto>?> GetAllRooms(int hotelId);
    Task CreateRoom(CreateRoomRequestDto request);
    Task UpdateRoom(UpdateRoomRequestDto request);
    Task RemoveRoom(int id);
}