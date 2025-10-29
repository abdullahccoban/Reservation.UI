using Reservation.UI.Interfaces.Repositories;
using Reservation.UI.Models.DTOs.Response.Hotel;
using Reservation.UI.Models.DTOs.Response.HotelAdmin;
using Reservation.UI.Repositories.Base;

namespace Reservation.UI.Repositories;

public class HotelAdminRepository : ApiClientBase, IHotelAdminRepository
{
    private readonly string _baseUrl = "http://localhost:5162/";
    
    public HotelAdminRepository(HttpClient httpClient) : base(httpClient) { }

    public async Task<List<HotelAdminResponseDto>?> GetAdminHotels(string email)
        => await GetAsync<List<HotelAdminResponseDto>>($"{_baseUrl}api/v1/hotelAdmin/getAdminHotels?userEmail={email}");
}