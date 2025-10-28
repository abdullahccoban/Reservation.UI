namespace Reservation.UI.Domains;

public class PhotoDomain
{
    public int Id { get; private set; }
    public int HotelId  { get; private set; }
    public string PhotoPath { get; private set; }

    public PhotoDomain(int hotelId, string photoPath, int id = 0)
    {
        if (string.IsNullOrEmpty(photoPath)) throw new ArgumentNullException();
        if (hotelId <= 0) throw new ArgumentOutOfRangeException();
        HotelId = hotelId;
        PhotoPath = photoPath;
        if (id > 0) Id = id;
    }
}