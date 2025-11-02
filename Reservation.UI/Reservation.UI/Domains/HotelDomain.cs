namespace Reservation.UI.Domains;

public class HotelDomain
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public int DailyCapacity { get; private set; }
    public string Country { get; private set; }
    public string City { get; private set; }
    public string Phone { get; private set; }
    public int StarCount { get; private set; }

    public HotelDomain(string name, string description, int dailyCapacity, string country, string city, string phone, int starCount)
    {
        if (string.IsNullOrEmpty(name)) throw new ArgumentNullException();
        if (string.IsNullOrEmpty(description)) throw new ArgumentNullException();
        if (string.IsNullOrEmpty(country)) throw new ArgumentNullException();
        if (string.IsNullOrEmpty(city)) throw new ArgumentNullException();
        if (string.IsNullOrEmpty(phone)) throw new ArgumentNullException();
        if (dailyCapacity <= 0) throw new ArgumentOutOfRangeException();
        if (starCount <= 0 || starCount > 5) throw new ArgumentOutOfRangeException();
        
        Name = name;
        Description = description;
        Country = country;
        City = city;
        Phone = phone;
        StarCount = starCount;
        DailyCapacity = dailyCapacity;
    }
}