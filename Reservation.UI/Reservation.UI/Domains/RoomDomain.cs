namespace Reservation.UI.Domains;

public class RoomDomain
{
    public int Id { get; private set; }
    public int HotelId { get; private set; }
    public string RoomType { get; private set; }
    public int Capacity { get; private set; }
    public int Count { get; private set; }

    public RoomDomain(int hotelId, string roomType, int capacity, int count, int id = 0)
    {
        if (string.IsNullOrEmpty(roomType)) throw new ArgumentNullException();
        if (capacity <= 0) throw new ArgumentOutOfRangeException();
        if (count <= 0) throw new ArgumentOutOfRangeException();
        if (hotelId <= 0) throw new ArgumentOutOfRangeException();
        RoomType = roomType;
        Capacity = capacity;
        Count = count;
        HotelId = hotelId;
        if (id != 0) Id = id;
    }
}