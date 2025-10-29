using Reservation.UI.Domains;
using Reservation.UI.Interfaces.Repositories;
using Reservation.UI.Interfaces.Services;
using Reservation.UI.Models.DTOs.Request.WorkingRange;
using Reservation.UI.Models.DTOs.Response.WorkingRange;

namespace Reservation.UI.Services;

public class WorkingRangeService : IWorkingRangeService
{
    private readonly IWorkingRangeRepository _repo;

    public WorkingRangeService(IWorkingRangeRepository repo)
    {
        _repo = repo;
    }

    public async Task<List<WorkingRangeResponseDto>?> GetAllWorkingRanges(int hotelId)
        => await _repo.GetWorkingRanges(hotelId);

    public async Task CreateWorkingRange(CreateWorkingRangeRequestDto request)
    {
        var domain = new WorkingRangeDomain(request.HotelId, request.Year, request.OpeningDate, request.ClosingDate);
        await _repo.CreateWorkingRange(domain);
    }

    public async Task UpdateWorkingRange(UpdateWorkingRangeRequestDto request)
    {
        var domain = new WorkingRangeDomain(request.HotelId, request.Year, request.OpeningDate, request.ClosingDate, request.Id);
        await _repo.UpdateWorkingRange(domain);
    }

    public async Task RemoveWorkingRange(int id)
        => await _repo.RemoveWorkingRange(id);
}