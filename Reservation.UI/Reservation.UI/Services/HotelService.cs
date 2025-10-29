using Reservation.UI.Interfaces.Repositories;
using Reservation.UI.Interfaces.Services;
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
}