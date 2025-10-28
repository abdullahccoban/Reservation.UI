using Reservation.UI.Domains;
using Reservation.UI.Models.DTOs.Response.Room;

namespace Reservation.UI.Interfaces.Repositories;

public interface IRoomPriceRepository
{
    Task<List<RoomPriceResponseDto>?> GetRoomPrices(int roomId);
    Task CreateRoomPrice(RoomPriceDomain model);
    Task UpdateRoomPrice(RoomPriceDomain model);
    Task RemoveRoomPrice(int id);
}