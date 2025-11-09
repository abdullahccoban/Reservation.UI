using Reservation.UI.Models.DTOs.Request.Hotel;
using Reservation.UI.Models.DTOs.Response;
using Reservation.UI.Models.DTOs.Response.Hotel;

namespace Reservation.UI.Interfaces.Services;

public interface IHotelService
{
    Task<List<HotelResponseDto>?> GetHotels(string email);
    Task<List<HotelCardResponseDto>?> GetHotelCards(string? userId);
    Task<PagedResult<HotelResponseDto>?> SearchHotels(HotelSearchRequestDto request);
    Task CreateHotel(CreateHotelRequestDto request);
    Task<HotelDetailDto?> GetHotelDetail(int id, string? userId);

}