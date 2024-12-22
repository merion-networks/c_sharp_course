using DependencyInjection.Models;
using Microsoft.EntityFrameworkCore;

public class ApplicationWebApiDbContext : DbContext
{
    public DbSet<WeatherForecast> WeatherForecasts { get; set; }
    public ApplicationWebApiDbContext(DbContextOptions<ApplicationWebApiDbContext> options)
    : base(options)
    {

    }
    public ApplicationWebApiDbContext()
    {
    }
}