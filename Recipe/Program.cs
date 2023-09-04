using Domain.Entities;
using Infrastructure;
using Infrastructure.Configuration;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using NuGet.Versioning;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<Context>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));
Bootstraper.Configure(builder.Services);
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
      .AddCookie();
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("MainAdminOnly", policy =>
    {
        policy.RequireRole("MainAdmin");
    });
    options.AddPolicy("UserOnly", policy =>
    {
        policy.RequireRole("User");
    });
    options.AddPolicy("AdminOnly", policy =>
    {
        policy.RequireRole("Admin");
    });

});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.Map("/Info", builder =>
{
    builder.Run(async context =>
    {
        if (context.User.Identity.IsAuthenticated)
        {
            if (context.User.IsInRole("User"))
            {
                await context.Response.WriteAsync(context.User.FindFirst(ClaimTypes.Email).ToString());
            }
            else
            {
                await context.Response.WriteAsync("admin");
            }
        }
        else
        {
            await context.Response.WriteAsync("unauthenticated");

        }
    });
});


app.MapRazorPages();

app.Run();
