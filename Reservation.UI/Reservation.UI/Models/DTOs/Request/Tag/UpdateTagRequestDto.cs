namespace Reservation.UI.Models.DTOs.Request.Tag;

public class UpdateTagRequestDto
{
    public int Id { get; set; }
    public int HotelId { get; set; }
    public required string Tag { get; set; }
}