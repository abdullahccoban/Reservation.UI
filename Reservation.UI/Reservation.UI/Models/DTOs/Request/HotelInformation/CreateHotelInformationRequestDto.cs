namespace Reservation.UI.Models.DTOs.Request.HotelInformation;

public class CreateHotelInformationRequestDto
{
    public int HotelId  { get; set; }
    public required string Description { get; set; }
}