using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp
{
    public class DataLoader
    {
        public string Data {  get; private set; }

        private DataLoader() { }

        public static async Task<DataLoader> CreateAsync()
        {
            var loader = new DataLoader();
            await loader.InitializeAsync();
            return loader;
        }

        private async Task InitializeAsync()
        {
            Data = await GetDataFromApiAsync("https://macademy.free.beeceptor.com/data");
        }

        public async Task<string> GetDataFromApiAsync(string url)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string date = await client.GetStringAsync(url);
                    return date;
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
