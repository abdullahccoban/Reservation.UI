namespace Reservation.UI.Models.DTOs.Request.Room;

public class CreateRoomFeatureRequestDto
{
    public int RoomId { get; set; }
    public required string Feature { get; set; }
}