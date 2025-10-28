using Reservation.UI.Domains;
using Reservation.UI.Interfaces.Repositories;
using Reservation.UI.Interfaces.Services;
using Reservation.UI.Models.DTOs.Request.Tag;
using Reservation.UI.Models.DTOs.Response.Tag;

namespace Reservation.UI.Services;

public class TagService : ITagService
{
    private readonly ITagRepository _repo;

    public TagService(ITagRepository repo)
    {
        _repo = repo;
    }

    public async Task<List<TagResponseDto>?> GetAllTags(int hotelId)
        => await _repo.GetHotelTags(hotelId);

    public async Task CreateTag(CreateTagRequestDto request)
    {
        var domain = new TagDomain(request.HotelId, request.Tag);
        await _repo.CreateTag(domain);
    }

    public async Task UpdateTag(UpdateTagRequestDto request)
    {
        var domain = new TagDomain(request.HotelId, request.Tag, request.Id);
        await _repo.UpdateTag(domain);
    }

    public async Task RemoveTag(int id)
        => await _repo.RemoveTag(id);
}