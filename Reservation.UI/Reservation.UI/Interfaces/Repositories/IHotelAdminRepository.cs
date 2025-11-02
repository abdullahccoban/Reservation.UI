using Reservation.UI.Domains;
using Reservation.UI.Models.DTOs.Response.HotelAdmin;

namespace Reservation.UI.Interfaces.Repositories;

public interface IHotelAdminRepository
{
    Task<List<HotelAdminResponseDto>?> GetHotelAdmins(int hotelId);
    Task CreateHotelAdmin(HotelAdminDomain model);
    Task UpdateHotelAdmin(HotelAdminDomain model);
    Task RemoveHotelAdmin(int id);
    Task<List<HotelAdminResponseDto>?> GetAdminHotels(string email);
}