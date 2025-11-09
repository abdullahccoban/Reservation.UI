namespace Reservation.UI.Models.DTOs.Response.Favorite;

public class FavoriteResponseDto
{
    public int Id { get; set; }
    public int HotelId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int StarCount { get; set; }
}