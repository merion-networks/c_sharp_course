using System.Text.Json;

namespace ExtensionMethodsLibrary.Helpers
{
    public static class HttpClientExtensions
    {
        public static async Task<T> GetJsonAsync<T>(this HttpClient httpClient, string url) where T : class
        {
            try
            {
                var response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<T>(jsonString);
            }
            catch (Exception ex)
            {
                throw new Exception($"Исключение в методе расширения: {ex.Message}");
            }
        }
    }
}
