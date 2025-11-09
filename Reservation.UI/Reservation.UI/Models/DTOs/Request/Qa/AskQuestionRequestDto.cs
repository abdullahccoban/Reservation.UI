namespace Reservation.UI.Models.DTOs.Request.Qa;

public class AskQuestionRequestDto
{
    public int HotelId { get; set; }
    public required string Question { get; set; }
    public DateTime QuestionDate { get; set; }
}