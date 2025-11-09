using Reservation.UI.Models.DTOs.Response.Comment;

namespace Reservation.UI.Interfaces.Repositories;

public interface ICommentRepository
{
    Task<List<CommentResponseDto>?> GetHotelComments(int id);
}