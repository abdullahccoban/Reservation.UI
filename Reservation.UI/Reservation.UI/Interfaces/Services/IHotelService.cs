using Reservation.UI.Models.DTOs.Response.Hotel;

namespace Reservation.UI.Interfaces.Services;

public interface IHotelService
{
    Task<List<HotelResponseDto>?> GetHotels(string email);
    Task<List<HotelCardResponseDto>?> GetHotelCards();
}