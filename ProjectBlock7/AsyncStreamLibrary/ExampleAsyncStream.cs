

using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AsyncStreamLibrary
{
    public class ExampleAsyncStream
    {
        public async Task ExampleNumberAsyncStream()
        {
            await foreach (var number in GetNumberAsync())
            {
                Console.WriteLine($"Получено число {number}");
            }

        }

        private async IAsyncEnumerable<int> GetNumberAsync()
        {
            for (int i = 0; i < 30; i++)
            {
                await Task.Delay(1000);
                yield return i;
            }
        }

        public async Task ExampleReadFileAsyncStream()
        {
            await foreach (var line in ReadLinesAsync("example.txt"))
            {
                Console.WriteLine($"Прочитано: {line}");
            }
        }

        private async IAsyncEnumerable<string> ReadLinesAsync(string filePath)
        {
            using var reader = new StreamReader(filePath);

            while (!reader.EndOfStream)
            {
                var line = await reader.ReadLineAsync();
                await Task.Delay(500);
                yield return line;
            }
        }


        public async Task ExampleBigReadFileAsyncStream()
        {
            await foreach (var line in ReadLinesFromFileAsync("example.txt"))
            {
                Console.WriteLine($"Прочитано: {line}");
            }
        }
        private async IAsyncEnumerable<string> ReadLinesFromFileAsync(string filePath)
        {
            using var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, true);
            using var reader = new StreamReader(stream);

            while (!reader.EndOfStream)
            {
                var line = await reader.ReadLineAsync();
                await Task.Delay(60);
                yield return line;
            }
        }


        public async Task ExampleCencellationTokenAsyncStream()
        {
            using var cts = new CancellationTokenSource();

            var task = ProcessDataAsynk(cts.Token);

            Console.WriteLine("Нажмите любую клавишу для отмены...");
            Console.ReadKey();
            cts.Cancel();

            try
            {
                await task;
            }
            catch (Exception)
            {
                Console.WriteLine("Операция отменена.");
            }
        }

        private async Task ProcessDataAsynk(CancellationToken token)
        {
            await foreach (var number in GetNumberAsync(token))
            {
                Console.WriteLine($"Получено число {number}");
            }
        }

        private async IAsyncEnumerable<int> GetNumberAsync(CancellationToken token = default)
        {
            for (int i = 0; i < 100; i++)
            {
                token.ThrowIfCancellationRequested();
                await Task.Delay(1000, token);
                yield return i;
            }
        }

        public async Task ExampleLINQAsyncStream()
        {
            try
            {
                await foreach (var result in GetNumberAsync()
                    .WhereAwait(async n => await IsEvenAsync(n))
                    .SelectAwait(async n => await SquareAsync(n)))
                {
                    Console.WriteLine(result);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async ValueTask<bool> IsEvenAsync(int number)
        {
            await Task.Delay(50);
            return number % 2 == 0;
        }

        private async ValueTask<int> SquareAsync(int number)
        {
            await Task.Delay(50);
            return number * number;
        }

        public async Task ExampleWebApiAsyncStream()
        {
            try
            {
                await foreach (var item in GetItemsFromApiAsync())
                {
                    Console.WriteLine(item);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private async IAsyncEnumerable<object> GetItemsFromApiAsync()
        {

            using var httpClient = new HttpClient();
            int page = 1;
            bool hasMorePages = true;

            while (hasMorePages)
            {
                var response = await httpClient.GetAsync($"https://macademy.free.beeceptor.com/data?page={page}");
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();


                if (!content.Contains("page"))
                {
                    hasMorePages = false;
                }
                else
                {
                    yield return content;
                }
                page++;
            }

        }
    }
}
