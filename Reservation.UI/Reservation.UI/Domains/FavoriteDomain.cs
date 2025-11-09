namespace Reservation.UI.Domains;

public class FavoriteDomain
{
    public int Id { get; private set; }
    public int HotelId { get; private set; }
    public string UserId { get; private set; }

    public FavoriteDomain(int hotelId, string userId, int id = 0)
    {
        if (hotelId <= 0) throw new ArgumentOutOfRangeException();
        if (userId == null) throw new ArgumentNullException();
        if (id > 0) Id = id;
        HotelId = hotelId;
        UserId = userId;
    }
}