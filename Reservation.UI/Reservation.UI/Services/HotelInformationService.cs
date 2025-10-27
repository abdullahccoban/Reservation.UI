using Reservation.UI.Domains;
using Reservation.UI.Interfaces.Repositories;
using Reservation.UI.Interfaces.Services;
using Reservation.UI.Models.DTOs.Request.HotelInformation;
using Reservation.UI.Models.DTOs.Response.HotelInformation;

namespace Reservation.UI.Services;

public class HotelInformationService : IHotelInformationService
{
    private readonly IHotelInformationRepository _repo;
    
    public HotelInformationService(IHotelInformationRepository repo)
    {
        _repo = repo;
    }
    
    public async Task<List<HotelInformationResponseDto>?> GetAllHotelInfos(int hotelId)
        => await _repo.GetHotelInfos(hotelId);

    public async Task CreateHotelInfo(CreateHotelInformationRequestDto request)
    {
        var domain = new HotelInformationDomain(request.HotelId, request.Description);
        await _repo.CreateHotelInfo(domain);
    }

    public async Task UpdateHotelInfo(UpdateHotelInformationRequestDto request)
    {
        var domain = new HotelInformationDomain(request.HotelId, request.Description, request.Id);
        await _repo.UpdateHotelInfo(domain);
    }

    public async Task RemoveHotelInfo(int id)
        => await _repo.RemoveHotelInfo(id);
}