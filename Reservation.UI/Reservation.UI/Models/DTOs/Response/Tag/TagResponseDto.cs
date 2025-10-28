namespace Reservation.UI.Models.DTOs.Response.Tag;

public class TagResponseDto
{
    public int Id { get; set; }
    public int HotelId { get; set; }
    public required string Tag { get; set; }
}