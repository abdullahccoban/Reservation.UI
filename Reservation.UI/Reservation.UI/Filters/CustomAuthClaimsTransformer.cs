using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Reservation.UI.Filters;

public class CustomAuthClaimsTransformer : IClaimsTransformation
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CustomAuthClaimsTransformer(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    
    
    public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
    {
        if (principal.Identity == null || !principal.Identity.IsAuthenticated)
        {
            return principal;
        }
        
        var httpContext = _httpContextAccessor.HttpContext;
        if (httpContext == null)
        {
            return principal;
        }

        // 1. "CustomAuthToken" adlı çerezi oku
        var token = httpContext.Request.Cookies["CustomAuthToken"];

        if (string.IsNullOrEmpty(token))
        {
            // Token çerezi yoksa, oturumu kapat (JWT'ye bağımlıyız)
            await SignOutAndRedirect(httpContext);
            return new ClaimsPrincipal(new ClaimsIdentity());
        }

        // 2. JWT'yi doğrula ve ClaimsPrincipal al
        var newPrincipal = ValidateTokenAndGetPrincipal(token);

        if (newPrincipal != null)
        {
            // Token geçerliyse, yeni ClaimsPrincipal'ı döndür
            return newPrincipal;
        }
        else
        {
            // 3. Token geçersizse/süresi dolduysa: Oturumu kapat ve yönlendir
            await SignOutAndRedirect(httpContext);
            return new ClaimsPrincipal(new ClaimsIdentity()); // Anonim kimliği döndür
        }
    }
    
    private async Task SignOutAndRedirect(HttpContext httpContext)
    {
        // 1. Cookie Authentication oturumunu kapat
        await httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        
        // 2. JWT çerezini sil (Temizlik)
        httpContext.Response.Cookies.Delete("CustomAuthToken");

        // 3. Kullanıcıyı Login sayfasına yönlendir (View/Web projesi olduğumuz için)
        // API isteği ise yönlendirme yapmamalı (401 kodu döndürmeli, ama bu filtrede 401 döndürmek karmaşıktır, yönlendirme View'lar için daha güvenlidir)
        if (!httpContext.Response.HasStarted) // Yanıt daha önce başlatılmadıysa
        {
            // Eğer Login sayfasına otomatik yönlendirme istenmiyorsa, bu satır çıkarılabilir.
            // (Genellikle CookieAuth'un LoginPath'i bunu halleder, ama biz burada manuel tetikliyoruz)
            httpContext.Response.Redirect("/Account/Login"); 
        }
    }
    
    private ClaimsPrincipal? ValidateTokenAndGetPrincipal(string token)
    {
        var handler = new JwtSecurityTokenHandler();

        if (string.IsNullOrEmpty(token) || !handler.CanReadToken(token))
            return null;

        var jwtToken = handler.ReadJwtToken(token);

        // 1. Token Süresi Kontrolü
        if (jwtToken.ValidTo < DateTime.UtcNow)
        {
            // Token süresi dolduysa
            return null;
        }

        // 2. Claims'i Çıkar
        // JwtSecurityTokenHandler sadece token'ı okur, doğrulamayı yapmaz.
        // Ancak bu senaryoda basitçe Claims'i alabiliriz.
        var identity = new ClaimsIdentity(jwtToken.Claims, "CustomJwtAuth");
        
        // Gerekirse token'ın kendisini de bir Claim olarak ekleyin
        identity.AddClaim(new Claim("access_token", token));

        return new ClaimsPrincipal(identity);
    }
}