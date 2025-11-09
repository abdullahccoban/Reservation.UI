using Reservation.UI.Models.DTOs.Response.Hotel;
using Reservation.UI.Models.DTOs.Response.HotelAdmin;
using Reservation.UI.Models.DTOs.Response.HotelInformation;
using Reservation.UI.Models.DTOs.Response.Photo;
using Reservation.UI.Models.DTOs.Response.Qa;
using Reservation.UI.Models.DTOs.Response.Room;
using Reservation.UI.Models.DTOs.Response.Tag;
using Reservation.UI.Models.DTOs.Response.WorkingRange;

namespace Reservation.UI.Models;

public class AdminViewModel
{
    public int HotelId { get; set; }
    public List<HotelInformationResponseDto>? HotelInfos { get; set; }
    public List<PhotoResponseDto>? Photos { get; set; }
    public List<TagResponseDto>? Tags { get; set; }
    public List<RoomResponseDto>? Rooms { get; set; }
    public List<WorkingRangeResponseDto>? WorkingRanges { get; set; }
    public List<HotelResponseDto>? Hotels { get; set; }
    public List<HotelAdminResponseDto>? HotelAdmins { get; set; }
    public List<QaResponseDto>? Qa { get; set; }
}