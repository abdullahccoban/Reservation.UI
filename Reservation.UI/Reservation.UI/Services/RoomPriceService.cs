using Reservation.UI.Domains;
using Reservation.UI.Interfaces.Repositories;
using Reservation.UI.Interfaces.Services;
using Reservation.UI.Models.DTOs.Request.Room;
using Reservation.UI.Models.DTOs.Response.Room;

namespace Reservation.UI.Services;

public class RoomPriceService : IRoomPriceService
{
    private readonly IRoomPriceRepository _repo;

    public RoomPriceService(IRoomPriceRepository repo)
    {
        _repo = repo;
    }

    public async Task<List<RoomPriceResponseDto>?> GetAllRoomPrices(int roomId)
        => await _repo.GetRoomPrices(roomId);

    public async Task CreateRoomPrice(CreateRoomPriceRequestDto request)
    {
        var domain = new RoomPriceDomain(request.RoomId, request.Price, request.StartDate, request.EndDate);
        await _repo.CreateRoomPrice(domain);
    }

    public async Task UpdateRoomPrice(UpdateRoomPriceRequestDto request)
    {
        var domain = new RoomPriceDomain(request.RoomId, request.Price, request.StartDate, request.EndDate, request.Id);
        await _repo.UpdateRoomPrice(domain);
    }

    public async Task RemoveRoomPrice(int id)
        => await _repo.RemoveRoomPrice(id);
}