using Reservation.UI.Domains;
using Reservation.UI.Models.DTOs.Request.HotelInformation;
using Reservation.UI.Models.DTOs.Response.HotelInformation;

namespace Reservation.UI.Interfaces.Repositories;

public interface IHotelInformationRepository
{
    Task<List<HotelInformationResponseDto>?> GetHotelInfos(int hotelId);
    Task CreateHotelInfo(HotelInformationDomain model);
    Task UpdateHotelInfo(HotelInformationDomain model);
    Task RemoveHotelInfo(int id);
}