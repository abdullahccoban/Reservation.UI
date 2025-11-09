using Reservation.UI.Models.DTOs.Response.Comment;

namespace Reservation.UI.Interfaces.Services;

public interface ICommentService
{
    Task<List<CommentResponseDto>?> GetHotelComments(int id);
}