namespace Reservation.UI.Models.DTOs.Response.HotelAdmin;

public class HotelAdminResponseDto
{
    public int Id { get; set; }
    public int HotelId { get; set; }
    public required string UserEmail { get; set; }
    
}