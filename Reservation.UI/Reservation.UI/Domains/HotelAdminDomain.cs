namespace Reservation.UI.Domains;

public class HotelAdminDomain
{
    public int Id { get; private set; }
    public int HotelId { get; private set; }
    public string UserEmail { get; private set; }

    public HotelAdminDomain(int hotelId, string userEmail, int id = 0)
    {
        if (string.IsNullOrEmpty(userEmail)) throw new ArgumentNullException();
        if (hotelId <= 0) throw new ArgumentOutOfRangeException();
        HotelId = hotelId;
        UserEmail = userEmail;
        if (id > 0) Id = id;
    }
}