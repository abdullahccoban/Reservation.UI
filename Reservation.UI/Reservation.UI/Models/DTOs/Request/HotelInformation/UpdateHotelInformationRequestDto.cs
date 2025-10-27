namespace Reservation.UI.Models.DTOs.Request.HotelInformation;

public class UpdateHotelInformationRequestDto
{
    public int Id { get; set; }
    public int HotelId { get; set; }
    public required string Description { get; set; }
}