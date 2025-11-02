namespace Reservation.UI.Models.DTOs.Response.Hotel;

public class HotelResponseDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public int DailyCapacity { get; set; }
    public string? Country { get; set; }
    public string? City { get; set; }
    public string? Phone { get; set; }
    public int StarCount { get; set; }
}