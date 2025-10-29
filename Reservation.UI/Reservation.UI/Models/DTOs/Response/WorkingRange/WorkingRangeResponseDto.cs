namespace Reservation.UI.Models.DTOs.Response.WorkingRange;

public class WorkingRangeResponseDto
{
    public int Id { get; set; }
    public int HotelId { get; set; }
    public int Year { get; set; }
    public DateTime OpeningDate { get; set; }
    public DateTime ClosingDate { get; set; }
}