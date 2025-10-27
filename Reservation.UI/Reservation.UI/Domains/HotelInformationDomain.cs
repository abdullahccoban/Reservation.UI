namespace Reservation.UI.Domains;

public class HotelInformationDomain
{
    public int Id { get; private set; }
    public int HotelId { get; private set; }
    public string Description { get; private set; }

    public HotelInformationDomain(int hotelId, string description, int id = 0)
    {
        if (string.IsNullOrEmpty(description)) throw new ArgumentNullException();
        if (hotelId <= 0) throw new ArgumentOutOfRangeException();
        HotelId = hotelId;
        Description = description;
        if (id > 0) Id = id;
    }
}