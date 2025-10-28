namespace Reservation.UI.Models.DTOs.Request.Room;

public class UpdateRoomFeatureRequestDto
{
    public int Id { get; set; }
    public int RoomId { get; set; }
    public required string Feature { get; set; }
}