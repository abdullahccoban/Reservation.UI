namespace Reservation.UI.Domains;

public class RoomPriceDomain
{
    public int Id { get; private set; }
    public int RoomId { get; private set; }
    public double Price { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }

    public RoomPriceDomain(int roomId, double price, DateTime startDate, DateTime endDate, int id = 0)
    {
        if (roomId <= 0) throw new ArgumentOutOfRangeException();
        if (price <= 0) throw new ArgumentOutOfRangeException();
        if (id != 0) Id = id;
        RoomId = roomId;
        Price = price;
        StartDate = startDate;
        EndDate = endDate;
    }
}