using Reservation.UI.Domains;
using Reservation.UI.Models.DTOs.Response.Room;

namespace Reservation.UI.Interfaces.Repositories;

public interface IRoomFeatureRepository
{
    Task<List<RoomFeatureResponseDto>?> GetRoomFeatures(int roomId);
    Task CreateRoomFeature(RoomFeatureDomain model);
    Task UpdateRoomFeature(RoomFeatureDomain model);
    Task RemoveRoomFeature(int id);
}