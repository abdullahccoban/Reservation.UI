using Reservation.UI.Domains;
using Reservation.UI.Interfaces.Repositories;
using Reservation.UI.Interfaces.Services;
using Reservation.UI.Models.DTOs.Request.Room;
using Reservation.UI.Models.DTOs.Response.Room;

namespace Reservation.UI.Services;

public class RoomFeatureService : IRoomFeatureService
{
    private readonly IRoomFeatureRepository _repo;

    public RoomFeatureService(IRoomFeatureRepository repo)
    {
        _repo = repo;
    }

    public async Task<List<RoomFeatureResponseDto>?> GetAllRoomFeatures(int roomId)
        => await _repo.GetRoomFeatures(roomId);

    public async Task CreateRoomFeature(CreateRoomFeatureRequestDto request)
    {
        var domain = new RoomFeatureDomain(request.RoomId, request.Feature);
        await _repo.CreateRoomFeature(domain);
    }

    public async Task UpdateRoomFeature(UpdateRoomFeatureRequestDto request)
    {
        var domain = new RoomFeatureDomain(request.RoomId, request.Feature, request.Id);
        await _repo.UpdateRoomFeature(domain);
    }

    public async Task RemoveRoomFeature(int id)
        => await _repo.RemoveRoomFeature(id);
}