using Microsoft.AspNetCore.Authorization;

namespace Reservation.UI.Filters;

public class HotelAccessRequirement : IAuthorizationRequirement { }

public class HotelAccessHandler : AuthorizationHandler<HotelAccessRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, HotelAccessRequirement requirement)
    {
        if (context.Resource is not HttpContext httpContext) return Task.CompletedTask;

        if (context.User.IsInRole("SuperAdmin"))
        {
            context.Succeed(requirement);
            return Task.CompletedTask;
        }
        
        var routeIdStr = httpContext.Request.RouteValues["hotelId"]?.ToString();
        if (!int.TryParse(routeIdStr, out int hotelId)) return Task.CompletedTask;

        var allowedHotelIds = context.User.Claims
            .Where(c => c.Type == "HotelId")
            .Select(c => int.Parse(c.Value));

        if (allowedHotelIds.Contains(hotelId))
            context.Succeed(requirement);

        return Task.CompletedTask;
    }
}