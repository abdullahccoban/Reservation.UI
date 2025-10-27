using System.Text;
using Newtonsoft.Json;
using Reservation.UI.Domains.Account;
using Reservation.UI.Interfaces.Repositories;
using Reservation.UI.Interfaces.Services;
using Reservation.UI.Models.DTOs.Request;
using Reservation.UI.Models.DTOs.Response;

namespace Reservation.UI.Services;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _repo;

    public AccountService(IAccountRepository repo)
    {
        _repo = repo;
    }
    
    public async Task<string?> Login(LoginRequestDto request)
    {
        var domain = new LoginDomain(request.Email, request.Password);
        return await _repo.Login(domain);
    }

    public async Task SignUp(RegisterRequestDto model)
    {
        var domain = new SignUpDomain(model.Email, model.Password, model.FullName, model.Phone);
        await _repo.SignUp(domain);
    }
}