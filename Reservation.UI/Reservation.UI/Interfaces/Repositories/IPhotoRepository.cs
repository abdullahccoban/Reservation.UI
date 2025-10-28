using Reservation.UI.Domains;
using Reservation.UI.Models.DTOs.Request.HotelInformation;
using Reservation.UI.Models.DTOs.Response.HotelInformation;
using Reservation.UI.Models.DTOs.Response.Photo;

namespace Reservation.UI.Interfaces.Repositories;

public interface IPhotoRepository
{
    Task<List<PhotoResponseDto>?> GetHotelPhotos(int hotelId);
    Task CreatePhoto(PhotoDomain model);
    Task UpdatePhoto(PhotoDomain model);
    Task RemovePhoto(int id);
}