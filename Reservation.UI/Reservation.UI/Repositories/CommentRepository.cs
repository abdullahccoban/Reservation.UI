using Reservation.UI.Interfaces.Repositories;
using Reservation.UI.Models.DTOs.Response.Comment;
using Reservation.UI.Repositories.Base;

namespace Reservation.UI.Repositories;

public class CommentRepository : ApiClientBase, ICommentRepository
{
    private readonly string _baseUrl = "http://localhost:5162/";
    
    public CommentRepository(HttpClient httpClient) : base(httpClient) { }
    
    public async Task<List<CommentResponseDto>?> GetHotelComments(int id)
        => await GetAsync<List<CommentResponseDto>>($"{_baseUrl}api/v1/comment/getAllByHotelId?hotelId={id}");
}