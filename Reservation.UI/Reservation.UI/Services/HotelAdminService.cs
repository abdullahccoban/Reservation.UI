using Reservation.UI.Domains;
using Reservation.UI.Interfaces.Repositories;
using Reservation.UI.Interfaces.Services;
using Reservation.UI.Models.DTOs.Request.HotelAdmin;
using Reservation.UI.Models.DTOs.Response.HotelAdmin;

namespace Reservation.UI.Services;

public class HotelAdminService : IHotelAdminService
{
    private readonly IHotelAdminRepository _repo;

    public HotelAdminService(IHotelAdminRepository repo)
    {
        _repo = repo;
    }

    public async Task<List<HotelAdminResponseDto>?> GetAllHotelAdmins(int hotelId)
        => await _repo.GetHotelAdmins(hotelId);

    public async Task CreateHotelAdmin(CreateHotelAdminRequestDto request)
    {
        var domain = new HotelAdminDomain(request.HotelId, request.UserEmail);
        await _repo.CreateHotelAdmin(domain);
    }

    public async Task UpdateHotelAdmin(UpdateHotelAdminRequestDto request)
    {
        var domain = new HotelAdminDomain(request.HotelId, request.UserEmail, request.Id);
        await _repo.UpdateHotelAdmin(domain);
    }

    public async Task RemoveHotelAdmin(int id)
        => await _repo.RemoveHotelAdmin(id);

    public async Task<List<HotelAdminResponseDto>?> GetAdminHotels(string email)
        => await _repo.GetAdminHotels(email);
}