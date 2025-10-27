using Reservation.UI.Domains.Account;

namespace Reservation.UI.Interfaces.Repositories;

public interface IAccountRepository
{
    Task<string?> Login(LoginDomain model);
    Task SignUp(SignUpDomain model);
}