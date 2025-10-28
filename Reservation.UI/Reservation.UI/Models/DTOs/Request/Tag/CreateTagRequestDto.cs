namespace Reservation.UI.Models.DTOs.Request.Tag;

public class CreateTagRequestDto
{
    public int HotelId { get; set; }
    public required string Tag { get; set; }
}