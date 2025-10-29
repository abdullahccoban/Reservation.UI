using Reservation.UI.Domains;
using Reservation.UI.Models.DTOs.Response.Room;
using Reservation.UI.Models.DTOs.Response.WorkingRange;

namespace Reservation.UI.Interfaces.Repositories;

public interface IWorkingRangeRepository
{
    Task<List<WorkingRangeResponseDto>?> GetWorkingRanges(int hotelId);
    Task CreateWorkingRange(WorkingRangeDomain model);
    Task UpdateWorkingRange(WorkingRangeDomain model);
    Task RemoveWorkingRange(int id);
}