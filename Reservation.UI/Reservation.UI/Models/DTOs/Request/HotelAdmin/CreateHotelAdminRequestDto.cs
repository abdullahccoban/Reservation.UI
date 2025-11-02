namespace Reservation.UI.Models.DTOs.Request.HotelAdmin;

public class CreateHotelAdminRequestDto
{
    public int HotelId { get; set; }
    public required string UserEmail { get; set; }
}