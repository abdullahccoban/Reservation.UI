namespace Reservation.UI.Models.DTOs.Response.Room;

public class RoomFeatureResponseDto
{
    public int Id { get; set; }
    public int RoomId { get; set; }
    public required string Feature { get; set; }
}