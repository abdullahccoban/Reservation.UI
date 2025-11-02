using Reservation.UI.Domains;
using Reservation.UI.Interfaces.Repositories;
using Reservation.UI.Models.DTOs.Response.HotelAdmin;
using Reservation.UI.Repositories.Base;

namespace Reservation.UI.Repositories;

public class HotelAdminRepository : ApiClientBase, IHotelAdminRepository
{
    private readonly string _baseUrl = "http://localhost:5162/";
    
    public HotelAdminRepository(HttpClient httpClient) : base(httpClient) { }

    public async Task<List<HotelAdminResponseDto>?> GetHotelAdmins(int hotelId)
        => await GetAsync<List<HotelAdminResponseDto>>($"{_baseUrl}api/v1/hotelAdmin/getAllByHotelId?hotelId={hotelId}");

    public async Task CreateHotelAdmin(HotelAdminDomain model)
        => await PostAsync<HotelAdminDomain, Task>($"{_baseUrl}api/v1/hotelAdmin/create", model);
    
    public async Task UpdateHotelAdmin(HotelAdminDomain model)
        => await PostAsync<HotelAdminDomain, Task>($"{_baseUrl}api/v1/hotelAdmin/update", model);

    public async Task RemoveHotelAdmin(int id)
        => await PostAsync<Task, Task>($"{_baseUrl}api/v1/hotelAdmin/remove?id={id}", null);

    public async Task<List<HotelAdminResponseDto>?> GetAdminHotels(string email)
        => await GetAsync<List<HotelAdminResponseDto>>($"{_baseUrl}api/v1/hotelAdmin/getAdminHotels?userEmail={email}");
}