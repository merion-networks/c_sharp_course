using DependencyInjection.DI.Interface;
using DependencyInjection.Models;
using Microsoft.EntityFrameworkCore;

namespace ProjectBlock9.WebApi.Data.Repository
{
    public class WeatherForecastRepository : IRepository<WeatherForecast>
    {
        private ApplicationWebApiDbContext context;

        public WeatherForecastRepository(ApplicationWebApiDbContext context)
        {
            this.context = context;
        }

        public void Create(WeatherForecast item)
        {
            context.WeatherForecasts.Add(item);
        }

        public void Delete(int id)
        {
            var wf =  Get(id);
            if (wf != null)
            {
                context.WeatherForecasts.Remove(wf);
            }
        }

        public WeatherForecast Get(int id)
        {
            return context.WeatherForecasts.FirstOrDefault(wf => wf.Id == id);
        }

        public IEnumerable<WeatherForecast> GetList()
        {
            return context.WeatherForecasts.ToList();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(WeatherForecast item)
        {
            context.Entry(item).State = EntityState.Modified;
        }

        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
