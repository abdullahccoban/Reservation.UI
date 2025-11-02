using Reservation.UI.Domains;
using Reservation.UI.Interfaces.Repositories;
using Reservation.UI.Models.DTOs.Request.Hotel;
using Reservation.UI.Models.DTOs.Response;
using Reservation.UI.Models.DTOs.Response.Hotel;
using Reservation.UI.Repositories.Base;

namespace Reservation.UI.Repositories;

public class HotelRepository : ApiClientBase, IHotelRepository
{
    private readonly string _baseUrl = "http://localhost:5162/";
    
    public HotelRepository(HttpClient httpClient) : base(httpClient)
    {
    }
    
    public async Task<PagedResult<HotelResponseDto>?> SearchHotels(HotelSearchRequestDto request)
        => await GetAsync<PagedResult<HotelResponseDto>>($"{_baseUrl}api/v1/hotel/searchHotels?page={request.Page}&pageSize={request.PageSize}&searchTerm={request.SearchTerm}");

    public async Task CreateHotel(HotelDomain model)
        => await PostAsync<HotelDomain, Task>($"{_baseUrl}api/v1/hotel/create", model);

    public async Task<List<HotelResponseDto>?> GetHotels(string email)
        => await GetAsync<List<HotelResponseDto>>($"{_baseUrl}api/v1/hotel/getHotelsForAdmins?email={email}");
    
    public async Task<List<HotelCardResponseDto>?> GetHotelCards()
        => await GetAsync<List<HotelCardResponseDto>>($"{_baseUrl}api/v1/hotel/getHotelsCard");
}