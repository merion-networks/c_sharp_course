using DependencyInjection.DI.Interface;
using System.Text;

namespace ApiLibrary
{
    public class HttpClientExample : IHttpClientExample
    {

        private async Task<string> HttpGet(string url)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage responseMessage = await client.GetAsync(url);
                responseMessage.EnsureSuccessStatusCode();
                string responseBody = await responseMessage.Content.ReadAsStringAsync();

                return responseBody;
            }
        }


        private async Task<string> HttpPost(string url, string jsonString)
        {
            using (var client = new HttpClient())
            {
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                HttpResponseMessage responseMessage = await client.PostAsync(url, content);
                responseMessage.EnsureSuccessStatusCode();
                string responseBody = await responseMessage.Content.ReadAsStringAsync();

                return responseBody;
            }
        }

        private async Task<string> HttpPut(string url, string jsonString)
        {
            using (var client = new HttpClient())
            {
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                HttpResponseMessage responseMessage = await client.PutAsync(url, content);
                responseMessage.EnsureSuccessStatusCode();
                string responseBody = await responseMessage.Content.ReadAsStringAsync();

                return responseBody;
            }
        }

        private async Task<string> HttpDelete(string url)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage responseMessage = await client.DeleteAsync(url);
                responseMessage.EnsureSuccessStatusCode();
                string responseBody = await responseMessage.Content.ReadAsStringAsync();

                return responseBody;
            }
        }

        public async Task<string> GetInfoSpaceX()
        {
            return await HttpGet("https://api.spacexdata.com/v3/info");
        }


        public async Task<string> GetWeatherForecast()
        {
            return await HttpGet("https://localhost:7155/WeatherForecast");
        }

        public async Task<string> PostWeatherForecast(string jsonString)
        {
            return await HttpPost("https://localhost:7155/WeatherForecast", jsonString);
        }

        public async Task<string> PutWeatherForecast(int id, string jsonString)
        {
            return await HttpPut($"https://localhost:7155/WeatherForecast/{id}", jsonString);
        }

        public async Task<string> DeleteWeatherForecast(int id)
        {
            return await HttpDelete($"https://localhost:7155/WeatherForecast/{id}");
        }
    }
}
