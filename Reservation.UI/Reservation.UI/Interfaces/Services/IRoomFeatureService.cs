using Reservation.UI.Models.DTOs.Request.Room;
using Reservation.UI.Models.DTOs.Response.Room;

namespace Reservation.UI.Interfaces.Services;

public interface IRoomFeatureService
{
    Task<List<RoomFeatureResponseDto>?> GetAllRoomFeatures(int roomId);
    Task CreateRoomFeature(CreateRoomFeatureRequestDto request);
    Task UpdateRoomFeature(UpdateRoomFeatureRequestDto request);
    Task RemoveRoomFeature(int id);
}