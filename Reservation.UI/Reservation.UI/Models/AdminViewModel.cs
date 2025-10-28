using Reservation.UI.Models.DTOs.Response.HotelInformation;
using Reservation.UI.Models.DTOs.Response.Photo;
using Reservation.UI.Models.DTOs.Response.Room;
using Reservation.UI.Models.DTOs.Response.Tag;

namespace Reservation.UI.Models;

public class AdminViewModel
{
    public int HotelId { get; set; }
    public List<HotelInformationResponseDto>? HotelInfos { get; set; }
    public List<PhotoResponseDto>? Photos { get; set; }
    public List<TagResponseDto>? Tags { get; set; }
    public List<RoomResponseDto>? Rooms { get; set; }
}