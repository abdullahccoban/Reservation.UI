using Reservation.UI.Domains;
using Reservation.UI.Models.DTOs.Request.Hotel;
using Reservation.UI.Models.DTOs.Response;
using Reservation.UI.Models.DTOs.Response.Hotel;

namespace Reservation.UI.Interfaces.Repositories;

public interface IHotelRepository
{
    Task<List<HotelResponseDto>?> GetHotels(string email);
    Task<List<HotelCardResponseDto>?> GetHotelCards(string? userId);
    Task<PagedResult<HotelResponseDto>?> SearchHotels(HotelSearchRequestDto request);
    Task CreateHotel(HotelDomain model);
    Task<HotelDetailDto?> GetHotelDetail(int id, string? userId);

}