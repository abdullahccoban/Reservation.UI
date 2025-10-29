using Reservation.UI.Models.DTOs.Response.HotelAdmin;

namespace Reservation.UI.Interfaces.Repositories;

public interface IHotelAdminRepository
{
    Task<List<HotelAdminResponseDto>?> GetAdminHotels(string email);
}