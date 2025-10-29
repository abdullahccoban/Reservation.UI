using Reservation.UI.Models.DTOs.Response.HotelAdmin;

namespace Reservation.UI.Interfaces.Services;

public interface IHotelAdminService
{
    Task<List<HotelAdminResponseDto>?> GetAdminHotels(string email);
}