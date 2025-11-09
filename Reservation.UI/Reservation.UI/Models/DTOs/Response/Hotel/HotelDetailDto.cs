using Reservation.UI.Models.DTOs.Response.Comment;
using Reservation.UI.Models.DTOs.Response.HotelInformation;
using Reservation.UI.Models.DTOs.Response.Photo;
using Reservation.UI.Models.DTOs.Response.Qa;
using Reservation.UI.Models.DTOs.Response.Room;
using Reservation.UI.Models.DTOs.Response.Tag;

namespace Reservation.UI.Models.DTOs.Response.Hotel;

public class HotelDetailDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int StarCount { get; set; }
    public List<PhotoResponseDto>? Photos { get; set; }
    public List<HotelInformationResponseDto>? HotelInformations { get; set; }
    public List<TagResponseDto>? Tags { get; set; }
    public List<RoomResponseDto>? Rooms { get; set; }
    public List<CommentResponseDto>? Comments { get; set; }
    public List<QaResponseDto>? Qas { get; set; }
    public double AverageScore  { get; set; }
    public int CommentCount  { get; set; }
}