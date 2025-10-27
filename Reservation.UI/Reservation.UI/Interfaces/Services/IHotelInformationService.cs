using Reservation.UI.Models.DTOs.Request.HotelInformation;
using Reservation.UI.Models.DTOs.Response.HotelInformation;

namespace Reservation.UI.Interfaces.Services;

public interface IHotelInformationService
{
    Task<List<HotelInformationResponseDto>?> GetAllHotelInfos(int hotelId);
    Task CreateHotelInfo(CreateHotelInformationRequestDto request);
    Task UpdateHotelInfo(UpdateHotelInformationRequestDto request);
    Task RemoveHotelInfo(int id);
}