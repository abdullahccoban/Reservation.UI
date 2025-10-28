using Reservation.UI.Models.DTOs.Request.Photo;
using Reservation.UI.Models.DTOs.Response.Photo;

namespace Reservation.UI.Interfaces.Services;

public interface IPhotoService
{
    Task<List<PhotoResponseDto>?> GetAllPhotos(int hotelId);
    Task CreatePhoto(CreatePhotoRequestDto request);
    Task UpdatePhoto(UpdatePhotoRequestDto request);
    Task RemovePhoto(int id);
}