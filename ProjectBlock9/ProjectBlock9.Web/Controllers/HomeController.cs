using DependencyInjection.DI.Interface;
using DependencyInjection.DI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DependencyInjection.Models;
using Microsoft.DotNet.MSIdentity.Shared;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ProjectBlock9.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientExample httpClient;

        public HomeController(IHttpClientExample client)
        {
            this.httpClient = client;
        }


        public IActionResult Index()
        {
            ViewData["Title"] = "Home";
            return View();
        }

        public async Task<IActionResult> SpaceXInfo()
        {
            var result = await httpClient.GetInfoSpaceX();

            Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(result);

            return View(myDeserializedClass);
        }


        public async Task<IActionResult> WeatherForecast()
        {
            var result = await httpClient.GetWeatherForecast();

            List<WeatherForecast> myDeserializedClass = JsonConvert.DeserializeObject<List<WeatherForecast>>(result);

            if (myDeserializedClass.Any())
            {
                return View(myDeserializedClass);
            }
            else
            {
                return View();
            }
        }

        public async Task<IActionResult> WeatherForecastPost()
        {

            WeatherForecast weatherForecast = new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(2)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = "TestPost"
            };
            string json = JsonConvert.SerializeObject(weatherForecast);

            var result = await httpClient.PostWeatherForecast(json);


            return RedirectToAction("WeatherForecast");
        }

        public async Task<IActionResult> WeatherForecastPut()
        {
            WeatherForecast weatherForecast = new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(2)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = "TestPut"
            };
            string json = JsonConvert.SerializeObject(weatherForecast);

            var result = await httpClient.PutWeatherForecast(Random.Shared.Next(10, 30), json);

            return RedirectToAction("WeatherForecast");
        }

        public async Task<IActionResult> WeatherForecastDelete()
        {
            var result = await httpClient.DeleteWeatherForecast(Random.Shared.Next(1,10));

            return RedirectToAction("WeatherForecast");
        }


        [Authorize]
        public IActionResult Privacy()
        {
            ViewData["Title"] = "Privacy";
            return View();
        }
    }
}
