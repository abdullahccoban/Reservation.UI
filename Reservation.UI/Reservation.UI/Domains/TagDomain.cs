namespace Reservation.UI.Domains;

public class TagDomain
{
    public int Id { get; private set; }
    public int HotelId { get; private set; }
    public string Tag { get; private set; }

    public TagDomain(int hotelId, string tag, int id = 0)
    {
        if (string.IsNullOrEmpty(tag)) throw new ArgumentNullException();
        if (hotelId <= 0) throw new ArgumentOutOfRangeException();
        HotelId = hotelId;
        Tag = tag;
        if (id != 0) Id = id;
    }
}