namespace Reservation.UI.Domains.Account;

public class SignUpDomain
{
    public string Email { get; private set; }
    public string Phone { get; private set; }
    public string FullName { get; private set; }
    public string Password { get; private set; }
    public int ProjectId { get; private set; }

    public SignUpDomain(string email, string password, string  fullName, string phone)
    {
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(phone)) throw new ArgumentNullException();
        Email = email;
        Password = password;
        FullName = fullName;
        Phone = phone;
        ProjectId = 1;
    }
}