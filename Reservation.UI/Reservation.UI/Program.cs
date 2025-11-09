using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Reservation.UI.Filters;
using Reservation.UI.Interfaces.Repositories;
using Reservation.UI.Interfaces.Services;
using Reservation.UI.Repositories;
using Reservation.UI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpContextAccessor();
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("HotelPermission", policy =>
        policy.Requirements.Add(new HotelAccessRequirement()));
});

builder.Services.AddSingleton<IAuthorizationHandler, HotelAccessHandler>();

builder.Services.AddScoped<IClaimsTransformation, CustomAuthClaimsTransformer>();
// ...

builder.Services.AddSingleton<HttpClient>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IHotelInformationService, HotelInformationService>();
builder.Services.AddScoped<IPhotoService, PhotoService>();
builder.Services.AddScoped<ITagService, TagService>();
builder.Services.AddScoped<IRoomService, RoomService>();
builder.Services.AddScoped<IRoomPriceService, RoomPriceService>();
builder.Services.AddScoped<IRoomFeatureService, RoomFeatureService>();
builder.Services.AddScoped<IWorkingRangeService, WorkingRangeService>();
builder.Services.AddScoped<IHotelService, HotelService>();
builder.Services.AddScoped<IHotelAdminService, HotelAdminService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IQaService, QaService>();
builder.Services.AddScoped<IFavoriteService, FavoriteService>();

builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IHotelInformationRepository, HotelInformationRepository>();
builder.Services.AddScoped<IPhotoRepository, PhotoRepository>();
builder.Services.AddScoped<ITagRepository, TagRepository>();
builder.Services.AddScoped<IRoomRepository, RoomRepository>();
builder.Services.AddScoped<IRoomPriceRepository, RoomPriceRepository>();
builder.Services.AddScoped<IRoomFeatureRepository, RoomFeatureRepository>();
builder.Services.AddScoped<IWorkingRangeRepository, WorkingRangeRepository>();
builder.Services.AddScoped<IHotelRepository, HotelRepository>();
builder.Services.AddScoped<IHotelAdminRepository, HotelAdminRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<IQaRepository, QaRepository>();
builder.Services.AddScoped<IFavoriteRepository, FavoriteRepository>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromHours(1); 
        options.LoginPath = "/Home/Index";
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();