using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection.DI.Interface
{
    public interface IHttpClientExample
    {
        Task<string> GetInfoSpaceX();
        Task<string> GetWeatherForecast();
        Task<string> PostWeatherForecast(string jsonString);
        Task<string> PutWeatherForecast(int id, string jsonString);
        Task<string> DeleteWeatherForecast(int id);
    }
}
