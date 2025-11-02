using Reservation.UI.Models.DTOs.Request.HotelAdmin;
using Reservation.UI.Models.DTOs.Response.HotelAdmin;

namespace Reservation.UI.Interfaces.Services;

public interface IHotelAdminService
{
    Task<List<HotelAdminResponseDto>?> GetAllHotelAdmins(int hotelId);
    Task CreateHotelAdmin(CreateHotelAdminRequestDto request);
    Task UpdateHotelAdmin(UpdateHotelAdminRequestDto request);
    Task RemoveHotelAdmin(int id);
    Task<List<HotelAdminResponseDto>?> GetAdminHotels(string email);
}