namespace Reservation.UI.Models.DTOs.Request.Favorite;

public class AddFavoriteRequestDto
{
    public int HotelId { get; set; }
    public string? UserId { get; set; }
}