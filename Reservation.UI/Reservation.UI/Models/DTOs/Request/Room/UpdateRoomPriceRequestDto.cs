namespace Reservation.UI.Models.DTOs.Request.Room;

public class UpdateRoomPriceRequestDto
{
    public int Id { get; set; }
    public int RoomId { get; set; }
    public double Price { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}