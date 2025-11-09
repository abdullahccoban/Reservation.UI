namespace Reservation.UI.Models.DTOs.Response.Room;

public class RoomResponseDto
{
    public int Id { get; set; }
    public int HotelId { get; set; }
    public required string RoomType { get; set; }
    public int Capacity { get; set; }
    public int Count { get; set; }
    public List<RoomPriceResponseDto> RoomPrices { get; set; }
    public List<RoomFeatureResponseDto> RoomFeatures { get; set; }
}