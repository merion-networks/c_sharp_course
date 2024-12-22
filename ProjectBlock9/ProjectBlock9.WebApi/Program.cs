using DependencyInjection.DI.Interface;
using DependencyInjection.DI.Service;
using DependencyInjection.Models;
using Microsoft.EntityFrameworkCore;
using ProjectBlock9.WebApi.Data.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationWebApiDbContext>(options =>
       options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IRepository<WeatherForecast>, WeatherForecastRepository> ();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
