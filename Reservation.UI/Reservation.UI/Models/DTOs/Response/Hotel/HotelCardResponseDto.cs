namespace Reservation.UI.Models.DTOs.Response.Hotel;

public class HotelCardResponseDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public double AverageScore { get; set; }
    public int CommentCount { get; set; }
    public double MinPrice { get; set; }
    public string? FirstPhotoPath { get; set; }
}