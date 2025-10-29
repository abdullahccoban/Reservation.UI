using Reservation.UI.Interfaces.Repositories;
using Reservation.UI.Interfaces.Services;
using Reservation.UI.Models.DTOs.Response.HotelAdmin;

namespace Reservation.UI.Services;

public class HotelAdminService : IHotelAdminService
{
    private readonly IHotelAdminRepository _repo;

    public HotelAdminService(IHotelAdminRepository repo)
    {
        _repo = repo;
    }

    public async Task<List<HotelAdminResponseDto>?> GetAdminHotels(string email)
        => await _repo.GetAdminHotels(email);
}