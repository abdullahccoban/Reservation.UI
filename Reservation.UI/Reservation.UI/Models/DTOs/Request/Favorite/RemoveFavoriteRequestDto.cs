namespace Reservation.UI.Models.DTOs.Request.Favorite;

public class RemoveFavoriteRequestDto
{
    public int HotelId { get; set; }
    public string? UserId { get; set; }
}