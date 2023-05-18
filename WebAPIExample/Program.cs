using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Configuration;
using Serilog;
using WebAPIExample.Business.BackgroundWorkers;
using WebAPIExample.Business.DependencyInjection;
using WebAPIEXample.Configuration;
using WebAPIExample.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json");

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

builder.Host.UseSerilog(Log.Logger);

// Add services to the container.

//Typically would include logging background workers
builder.AddBackgroundWorkerServices();
//Dependency Injection logic
builder.AddInjectors(WebsiteType.StandardCoreSite);

//Database Logic
//I add my enviroment variables when the docker container is created
//if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable("connectionString")))
//    throw new Exception("connectionString enviroment variable is empty");
//builder.Services.AddDbContext<DataContext>(options =>
//options.UseSqlServer(Environment.GetEnvironmentVariable(Environment.GetEnvironmentVariable("connectionString"))));


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