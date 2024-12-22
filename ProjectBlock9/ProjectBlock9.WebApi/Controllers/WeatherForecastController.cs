using DependencyInjection.DI.Interface;
using DependencyInjection.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProjectBlock9.WebApi.Data.Repository;
using System.Text.Json.Nodes;

namespace ProjectBlock9.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IRepository<WeatherForecast> repository;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IRepository<WeatherForecast> repository)
        {
            _logger = logger;
            this.repository = repository;
            Init();
        }

        private void Init()
        {
            if (!repository.GetList().Any())
            {
               var collection = Enumerable.Range(1, 10).Select(index => new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                }).ToList();

                foreach (var item in collection)
                {
                    repository.Create(item);                       
                }

                repository.Save();
            }
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return repository.GetList();
        }

        [HttpPost]
        public IActionResult Post([FromBody] JsonObject json)
        {
            if(json == null)
            {
                return BadRequest("Invalid JSON data");
            }

           var weatherForecast = JsonConvert.DeserializeObject<WeatherForecast>(json.ToString());

            repository.Create(weatherForecast);
            repository.Save();

            return Ok("JSON data processed successfully"); 
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] JsonObject json)
        {
            if (json == null)
            {
                return BadRequest("Invalid JSON data");
            }

            var weatherForecast = JsonConvert.DeserializeObject<WeatherForecast>(json.ToString());

            var wf = repository.Get(id);
            if (wf == null)
            {
                return NotFound();
            }

            wf.TemperatureC = weatherForecast.TemperatureC;
            wf.Date = weatherForecast.Date;
            wf.Summary = weatherForecast.Summary;

            repository.Update(wf);
            repository.Save();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<WeatherForecast>> Delete(int id)
        {
            var wf = repository.Get(id);
            if (wf == null)
            {
                return NotFound();
            }
            repository.Delete(id);
            repository.Save();

            return NoContent();
        }
    }
}
