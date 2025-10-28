using Reservation.UI.Domains;
using Reservation.UI.Interfaces.Repositories;
using Reservation.UI.Interfaces.Services;
using Reservation.UI.Models.DTOs.Request.Photo;
using Reservation.UI.Models.DTOs.Response.Photo;

namespace Reservation.UI.Services;

public class PhotoService : IPhotoService
{
    private readonly IPhotoRepository _repo;

    public PhotoService(IPhotoRepository repo)
    {
        _repo = repo;
    }

    public async Task<List<PhotoResponseDto>?> GetAllPhotos(int hotelId)
        => await _repo.GetHotelPhotos(hotelId);

    public async Task CreatePhoto(CreatePhotoRequestDto request)
    {
        var domain = new PhotoDomain(request.HotelId, request.PhotoPath);
        await _repo.CreatePhoto(domain);
    }

    public async Task UpdatePhoto(UpdatePhotoRequestDto request)
    {
        var domain = new PhotoDomain(request.HotelId, request.PhotoPath, request.Id);
        await _repo.UpdatePhoto(domain);
    }

    public async Task RemovePhoto(int id)
        => await _repo.RemovePhoto(id);
}