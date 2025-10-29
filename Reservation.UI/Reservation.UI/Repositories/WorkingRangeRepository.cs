using Reservation.UI.Domains;
using Reservation.UI.Interfaces.Repositories;
using Reservation.UI.Models.DTOs.Response.WorkingRange;
using Reservation.UI.Repositories.Base;

namespace Reservation.UI.Repositories;

public class WorkingRangeRepository : ApiClientBase, IWorkingRangeRepository
{
    private readonly string _baseUrl = "http://localhost:5162/";
    
    public WorkingRangeRepository(HttpClient httpClient) : base(httpClient) { }

    public async Task<List<WorkingRangeResponseDto>?> GetWorkingRanges(int hotelId)
        => await GetAsync<List<WorkingRangeResponseDto>>($"{_baseUrl}api/v1/workingRange/getAllByHotelId?hotelId={hotelId}");

    public async Task CreateWorkingRange(WorkingRangeDomain model)
        => await PostAsync<WorkingRangeDomain, Task>($"{_baseUrl}api/v1/workingRange/create", model);

    public async Task UpdateWorkingRange(WorkingRangeDomain model)
        => await PostAsync<WorkingRangeDomain, Task>($"{_baseUrl}api/v1/workingRange/update", model);

    public async Task RemoveWorkingRange(int id)
        => await PostAsync<Task, Task>($"{_baseUrl}api/v1/workingRange/remove?id={id}", null);
}