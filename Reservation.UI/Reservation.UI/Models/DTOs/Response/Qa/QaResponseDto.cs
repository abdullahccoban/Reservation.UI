namespace Reservation.UI.Models.DTOs.Response.Qa;

public class QaResponseDto
{
    public int Id { get; set; }
    public int HotelId { get; set; }
    public string? Question { get; set; }
    public DateTime? QuestionDate { get; set; }
    public string? Answer { get; set; }
    public DateTime? AnswerDate { get; set; }
}