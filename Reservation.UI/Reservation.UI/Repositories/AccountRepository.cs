using Reservation.UI.Domains.Account;
using Reservation.UI.Interfaces.Repositories;
using Reservation.UI.Models.DTOs.Response;
using Reservation.UI.Repositories.Base;

namespace Reservation.UI.Repositories;

public class AccountRepository : ApiClientBase, IAccountRepository
{
    private readonly string _tokenEndpoint = "http://localhost:5146";
    
    public AccountRepository(HttpClient httpClient) : base(httpClient) { }

    public async Task<string?> Login(LoginDomain model)
    {
        var response = await PostAsync<LoginDomain, LoginResponseDto>($"{_tokenEndpoint}/api/v1/auth/login", model);
        return response?.accessToken;
    }

    public async Task SignUp(SignUpDomain model)
    {
        await PostAsync<SignUpDomain, Task>($"{_tokenEndpoint}/api/v1/auth/register", model);
    }
    
}