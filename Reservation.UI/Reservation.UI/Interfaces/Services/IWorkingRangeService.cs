using Reservation.UI.Models.DTOs.Request.WorkingRange;
using Reservation.UI.Models.DTOs.Response.WorkingRange;

namespace Reservation.UI.Interfaces.Services;

public interface IWorkingRangeService
{
    Task<List<WorkingRangeResponseDto>?> GetAllWorkingRanges(int hotelId);
    Task CreateWorkingRange(CreateWorkingRangeRequestDto request);
    Task UpdateWorkingRange(UpdateWorkingRangeRequestDto request);
    Task RemoveWorkingRange(int id);
}