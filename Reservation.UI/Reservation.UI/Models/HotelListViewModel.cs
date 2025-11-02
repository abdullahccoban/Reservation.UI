using Reservation.UI.Models.DTOs.Response.Hotel;

namespace Reservation.UI.Models;

public class HotelListViewModel
{
    public List<HotelResponseDto> Items { get; set; } = new();
    public string? SearchTerm { get; set; }
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 20;
    public int TotalCount { get; set; }
    public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
}
