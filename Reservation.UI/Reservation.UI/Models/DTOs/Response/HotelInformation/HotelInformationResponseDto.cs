namespace Reservation.UI.Models.DTOs.Response.HotelInformation;

public class HotelInformationResponseDto
{
    public int Id { get; set; }
    public int HotelId { get; set; }
    public required string Description { get; set; }
}