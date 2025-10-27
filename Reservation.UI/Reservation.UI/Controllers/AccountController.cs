using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Reservation.UI.Interfaces.Services;
using Reservation.UI.Models.DTOs.Request;

namespace Reservation.UI.Controllers;

public class AccountController : Controller
{
    private readonly IAccountService _accountService;
    
    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }
    
    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto model)
    {
        string? accessToken = await _accountService.Login(model);

        if (string.IsNullOrEmpty(accessToken)) return Unauthorized();
        
        HttpContext.Response.Cookies.Append("CustomAuthToken", accessToken, new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.Strict,
            Expires = DateTimeOffset.UtcNow.AddHours(1)
        });

        var placeholderClaims = new List<Claim> { new Claim(ClaimTypes.Name, model.Email) };
        var placeholderIdentity = new ClaimsIdentity(placeholderClaims, CookieAuthenticationDefaults.AuthenticationScheme);
        var placeholderPrincipal = new ClaimsPrincipal(placeholderIdentity);
        
        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            placeholderPrincipal,
            new AuthenticationProperties 
            { 
                IsPersistent = true,
                ExpiresUtc = DateTimeOffset.UtcNow.AddHours(1)
            });

        return Ok();
    }
    
    [HttpGet]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        HttpContext.Response.Cookies.Delete("CustomAuthToken");
        return RedirectToAction("Index", "Home");
    }

    [HttpPost]
    public async Task<IActionResult> Register([FromBody] RegisterRequestDto model)
    {
        await _accountService.SignUp(model);
        return Ok();
    }
}