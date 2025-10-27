using Reservation.UI.Domains;
using Reservation.UI.Interfaces.Repositories;
using Reservation.UI.Models.DTOs.Response.HotelInformation;
using Reservation.UI.Repositories.Base;

namespace Reservation.UI.Repositories;

public class HotelInformationRepository : ApiClientBase, IHotelInformationRepository
{
    private readonly string _baseUrl = "http://localhost:5162/";

    public HotelInformationRepository(HttpClient httpClient) : base(httpClient) { }

    public async Task<List<HotelInformationResponseDto>?> GetHotelInfos(int hotelId)
        => await GetAsync<List<HotelInformationResponseDto>>($"{_baseUrl}api/v1/hotelInfo/getAllByHotelId?hotelId={hotelId}");

    public async Task CreateHotelInfo(HotelInformationDomain model)
        => await PostAsync<HotelInformationDomain, Task>($"{_baseUrl}api/v1/hotelInfo/create", model);
    

    public async Task UpdateHotelInfo(HotelInformationDomain model)
        => await PostAsync<HotelInformationDomain, Task>($"{_baseUrl}api/v1/hotelInfo/update", model);

    public async Task RemoveHotelInfo(int id)
        => await PostAsync<Task, Task>($"{_baseUrl}api/v1/hotelInfo/remove?id={id}", null);
}