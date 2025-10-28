using Reservation.UI.Models.DTOs.Request.Tag;
using Reservation.UI.Models.DTOs.Response.Tag;

namespace Reservation.UI.Interfaces.Services;

public interface ITagService
{
    Task<List<TagResponseDto>?> GetAllTags(int hotelId);
    Task CreateTag(CreateTagRequestDto request);
    Task UpdateTag(UpdateTagRequestDto request);
    Task RemoveTag(int id);
}