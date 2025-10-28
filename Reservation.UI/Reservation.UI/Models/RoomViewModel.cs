using Reservation.UI.Models.DTOs.Response.Room;

namespace Reservation.UI.Models;

public class RoomViewModel
{
    public int RoomId { get; set; }
    public RoomResponseDto? Room { get; set; }
    public List<RoomFeatureResponseDto>? RoomFeatures { get; set; }
    public List<RoomPriceResponseDto>? RoomPrices { get; set; }
}