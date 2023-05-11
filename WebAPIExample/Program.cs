using Microsoft.AspNetCore.Authentication.Cookies;
using Serilog;
using WebAPIExample.Business.BackgroundWorkers;
using WebAPIExample.Business.DependencyInjection;
using static WebAPIExample.Business.Constants.Auth;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json");

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

builder.Host.UseSerilog(Log.Logger);

// Add services to the container.

//builder.AddBackgroundWorkerServices();
//builder.AddInjectors();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
  .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, o => o.LoginPath = new PathString("/Login"));

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("LoggedIn", policy => policy.RequireRole("Authenticated"));
});

builder.Services.AddSession(options =>
{
    options.Cookie.Name = "SessionCookie";
    options.Cookie.Domain = "localhost";
    options.Cookie.Path = "/";
    options.Cookie.HttpOnly = false;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    options.Cookie.IsEssential = true;
});
builder.Services.AddDistributedMemoryCache();

var app = builder.Build();
app.UseSerilogRequestLogging();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseSession();

app.MapControllers();

try
{
    Log.Information("Application starting up");
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "The application failed to start correctly.");
}
finally
{
    Log.CloseAndFlush();
}