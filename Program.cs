using MEDICINE.WEB.Data;
using MEDICINE.WEB.Filters;
using MEDICINE.WEB.Helpers;
using MEDICINE.WEB.Services.Admin;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<AdminAuthorizationFilter>();
builder.Services.AddScoped<AdminNavigationService>();
//builder.Services.AddScoped<PermissionAuthorizationFilter>();

builder.Services
.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
.AddCookie(options =>
{
    options.LoginPath = "/Admin/Account/Login";

    options.AccessDeniedPath = "/Admin/Account/AccessDenied";

    options.ExpireTimeSpan = TimeSpan.FromDays(30);

    options.SlidingExpiration = true;

    options.Cookie.HttpOnly = true;

    options.Cookie.IsEssential = true;
});

// Session Configuration
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromHours(8);

    options.Cookie.HttpOnly = true;

    options.Cookie.IsEssential = true;
});

// Database Connection
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

// Enable Session
app.UseSession();

// Future Authentication Middleware
app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// TEMPORARY PASSWORD HASH GENERATION
var passwordHelper = new PasswordHelper();

Console.WriteLine(
    passwordHelper.HashPassword("Admin@123")
);

app.Run();