namespace Reservation.UI.Models.DTOs.Response.Photo;

public class PhotoResponseDto
{
    public int Id { get; set; }
    public int HotelId { get; set; }
    public required string PhotoPath { get; set; }
}