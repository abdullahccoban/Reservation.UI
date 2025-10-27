namespace Reservation.UI.Domains.Account;

public class LoginDomain
{
    public string Email { get; private set; }
    public string Password { get; private set; }

    public LoginDomain(string email, string password)
    {
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password)) throw new ArgumentNullException();
        Email = email;
        Password = password;
    }
}