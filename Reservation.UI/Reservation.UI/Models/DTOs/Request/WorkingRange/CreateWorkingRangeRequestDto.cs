namespace Reservation.UI.Models.DTOs.Request.WorkingRange;

public class CreateWorkingRangeRequestDto
{
    public int HotelId { get; set; }
    public int Year { get; set; }
    public DateTime OpeningDate { get; set; }
    public DateTime ClosingDate { get; set; }
}