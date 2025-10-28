using Reservation.UI.Models.DTOs.Request.Room;
using Reservation.UI.Models.DTOs.Response.Room;

namespace Reservation.UI.Interfaces.Services;

public interface IRoomPriceService
{
    Task<List<RoomPriceResponseDto>?> GetAllRoomPrices(int roomId);
    Task CreateRoomPrice(CreateRoomPriceRequestDto request);
    Task UpdateRoomPrice(UpdateRoomPriceRequestDto request);
    Task RemoveRoomPrice(int id);
}