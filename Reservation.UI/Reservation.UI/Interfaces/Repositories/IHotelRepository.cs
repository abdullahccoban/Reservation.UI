using Reservation.UI.Models.DTOs.Response.Hotel;

namespace Reservation.UI.Interfaces.Repositories;

public interface IHotelRepository
{
    Task<List<HotelResponseDto>?> GetHotels(string email);
    Task<List<HotelCardResponseDto>?> GetHotelCards();
}