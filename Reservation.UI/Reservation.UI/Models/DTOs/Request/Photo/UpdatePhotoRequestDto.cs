namespace Reservation.UI.Models.DTOs.Request.Photo;

public class UpdatePhotoRequestDto
{
    public int Id { get; set; }
    public int HotelId { get; set; }
    public required string PhotoPath { get; set; }
}