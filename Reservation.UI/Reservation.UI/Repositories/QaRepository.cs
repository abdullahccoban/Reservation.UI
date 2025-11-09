using Reservation.UI.Domains;
using Reservation.UI.Interfaces.Repositories;
using Reservation.UI.Models.DTOs.Response.Qa;
using Reservation.UI.Repositories.Base;

namespace Reservation.UI.Repositories;

public class QaRepository : ApiClientBase, IQaRepository
{
    private readonly string _baseUrl = "http://localhost:5162/";
    
    public QaRepository(HttpClient httpClient) : base(httpClient) { }
    
    public async Task<List<QaResponseDto>?> GetAnsweredQuestions(int hotelId)
        => await GetAsync<List<QaResponseDto>>($"{_baseUrl}api/v1/qa/getAllAnsweredByHotelId?hotelId={hotelId}");

    public async Task AskQuestion(QaDomain model)
        => await PostAsync<QaDomain, Task>($"{_baseUrl}api/v1/qa/create", model);

    public async Task<List<QaResponseDto>?> GetAllQuestions(int hotelId)
        => await GetAsync<List<QaResponseDto>>($"{_baseUrl}api/v1/qa/getAllByHotelId?hotelId={hotelId}");

    public async Task<QaResponseDto?> GetQuestion(int id)
        => await GetAsync<QaResponseDto>($"{_baseUrl}api/v1/qa/getById?id={id}");
    
    public async Task Answer(QaDomain model)
        => await PostAsync<QaDomain, Task>($"{_baseUrl}api/v1/qa/update", model);
}