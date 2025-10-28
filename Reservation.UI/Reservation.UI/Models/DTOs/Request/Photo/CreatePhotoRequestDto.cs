namespace Reservation.UI.Models.DTOs.Request.Photo;

public class CreatePhotoRequestDto
{
    public int HotelId  { get; set; }
    public required string PhotoPath { get; set; }
}