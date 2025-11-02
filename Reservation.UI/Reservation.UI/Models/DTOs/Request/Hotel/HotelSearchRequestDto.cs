namespace Reservation.UI.Models.DTOs.Request.Hotel;

public class HotelSearchRequestDto
{
    public string? SearchTerm { get; set; } = "";
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 20;
}