using Reservation.UI.Domains;
using Reservation.UI.Interfaces.Repositories;
using Reservation.UI.Interfaces.Services;
using Reservation.UI.Models.DTOs.Request.Hotel;
using Reservation.UI.Models.DTOs.Response;
using Reservation.UI.Models.DTOs.Response.Hotel;

namespace Reservation.UI.Services;

public class HotelService : IHotelService
{
    private readonly IHotelRepository _repo;

    public HotelService(IHotelRepository repo)
    {
        _repo = repo;
    }
    
    public async Task<List<HotelResponseDto>?> GetHotels(string email)
        => await _repo.GetHotels(email);
    
    public async Task<List<HotelCardResponseDto>?> GetHotelCards()
        => await _repo.GetHotelCards();
    
    public async Task<PagedResult<HotelResponseDto>?> SearchHotels(HotelSearchRequestDto request)
        => await _repo.SearchHotels(request);

    public async Task CreateHotel(CreateHotelRequestDto request)
    {
        var domain = new HotelDomain(request.Name, request.Description, request.DailyCapacity, request.Country, request.City, request.Phone, request.StarCount);
        await _repo.CreateHotel(domain);
    }
}