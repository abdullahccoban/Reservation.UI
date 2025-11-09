namespace Reservation.UI.Models.DTOs.Response.Comment;

public class CommentResponseDto
{
    public int Id { get; set; }
    public int HotelId { get; set; }
    public int Point { get; set; }
    public string? Comment { get; set; }
    public DateTime? CreatedAt { get; set; }
}