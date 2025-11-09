using Reservation.UI.Interfaces.Repositories;
using Reservation.UI.Interfaces.Services;
using Reservation.UI.Models.DTOs.Response.Comment;

namespace Reservation.UI.Services;

public class CommentService : ICommentService
{
    private readonly ICommentRepository _commentRepository;

    public CommentService(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }

    public async Task<List<CommentResponseDto>?> GetHotelComments(int id)
        => await _commentRepository.GetHotelComments(id);
}