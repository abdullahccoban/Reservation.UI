namespace Reservation.UI.Domains;

public class RoomFeatureDomain
{
    public int Id { get; private set; }
    public int RoomId { get; private set; }
    public string Feature { get; private set; }

    
    public RoomFeatureDomain(int roomId, string feature, int id = 0)
    {
        if (string.IsNullOrEmpty(feature)) throw new ArgumentNullException();
        if (roomId <= 0) throw new ArgumentOutOfRangeException();
        if (id != 0) Id = id;
        Feature = feature;
        RoomId = roomId;
    }
}