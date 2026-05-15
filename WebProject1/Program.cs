
using Microsoft.AspNetCore.Authentication.Cookies;
using WebProject1.Interfaces;
using WebProject1.Repositories;
var builder = WebApplication.CreateBuilder(args);

//Configurara serviço de autenticação do sistema

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/User/Login";
        options.AccessDeniedPath = "/User/Denied";
    });

builder.Services.AddScoped<IUserRepositorie, UserRepositorie>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
