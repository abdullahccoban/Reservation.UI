using Reservation.UI.Models.DTOs.Response.HotelInformation;

namespace Reservation.UI.Models;

public class AdminViewModel
{
    public int HotelId { get; set; }
    public List<HotelInformationResponseDto>? HotelInfos { get; set; }
}