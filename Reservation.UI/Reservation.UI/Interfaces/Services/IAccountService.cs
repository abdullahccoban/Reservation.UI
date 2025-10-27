using Reservation.UI.Models.DTOs.Request;

namespace Reservation.UI.Interfaces.Services;

public interface IAccountService
{
    Task<string?> Login(LoginRequestDto request);
    Task SignUp(RegisterRequestDto model);
}