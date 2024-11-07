using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlock6
{
    public class AsyncClass
    {

        public async Task<string> LoadDataAsync()
        {
            var data = await GetDataServer();

            return data;
        }

        private async Task<string> GetDataServer()
        {
            Thread.Sleep(10000);
            return "Данные получены";
        }

        public async Task Example()
        {
             await LoadDataAsync();
        }
    }
}
