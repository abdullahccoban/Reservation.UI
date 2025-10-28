using Reservation.UI.Domains;
using Reservation.UI.Models.DTOs.Response.Tag;

namespace Reservation.UI.Interfaces.Repositories;

public interface ITagRepository
{
    Task<List<TagResponseDto>?> GetHotelTags(int hotelId);
    Task CreateTag(TagDomain model);
    Task UpdateTag(TagDomain model);
    Task RemoveTag(int id);
}