namespace Reservation.UI.Domains;

public class WorkingRangeDomain
{
    public int Id { get; private set; }
    public int HotelId { get; private set; }
    public int Year { get; private set; }
    public DateTime OpeningDate { get; private set; }
    public DateTime ClosingDate { get; private set; }

    public WorkingRangeDomain(int hotelId, int year, DateTime openingDate, DateTime closingDate, int id = 0)
    {
        if (hotelId <= 0) throw new ArgumentOutOfRangeException();
        if (year <= 2020) throw new ArgumentOutOfRangeException();
        if (id != 0) Id = id;
        HotelId = hotelId;
        Year = year;
        OpeningDate = openingDate;
        ClosingDate = closingDate;
    }
}