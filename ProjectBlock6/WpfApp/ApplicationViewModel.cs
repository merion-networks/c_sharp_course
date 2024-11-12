using Prism.Commands;
using System.ComponentModel;
using System.Windows.Controls;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Security.Cryptography.X509Certificates;
using System.Net.Http;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text;
using System.IO;

namespace WpfApp
{
    class ApplicationViewModel : INotifyPropertyChanged
    {
        private string title;
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        private string anothertitle;
        public string AnotherTitle
        {
            get { return anothertitle; }
            set
            {
                anothertitle = value;
                OnPropertyChanged(nameof(AnotherTitle));
            }
        }

        private string exampleMultiAsync;
        public string ExampleMultiAsync
        {
            get { return exampleMultiAsync; }
            set
            {
                exampleMultiAsync = value;
                OnPropertyChanged(nameof(ExampleMultiAsync));
            }
        }

        private string exampleMultiEndAsync;
        public string ExampleMultiEndAsync
        {
            get { return exampleMultiEndAsync; }
            set
            {
                exampleMultiEndAsync = value;
                OnPropertyChanged(nameof(ExampleMultiEndAsync));
            }
        }

        private string lgError;
        public string LogError
        {
            get { return lgError; }
            set
            {
                lgError = value;
                OnPropertyChanged(nameof(LogError));
            }
        }

        private readonly object lockObject = new object();

        private ReaderWriterLockSlim readerWriterLock = new ReaderWriterLockSlim();

        private int sharedResource = 0;

        private List<int> dataInts = new List<int>();

        private List<string> apiUrl = new List<string>
        {
            "https://macademy.free.beeceptor.com/todos", "https://macademy.free.beeceptor.com/data", "https://macademy.free.beeceptor.com/", "https://macademy.free.beeceptor.com/", "https://macademy.free.beeceptor.com/", "https://macademy.free.beeceptor.com/"
        };

        private DelegateCommand newCommand;
        private DelegateCommand anotherCommand;

        public DelegateCommand NewCommand { get { return newCommand; } }
        public DelegateCommand AnotherCommand { get { return anotherCommand; } }


        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }


        public event Func<object, EventArgs, Task> DataProcessedAsync;

        protected virtual async Task OnDataProcessedAsync()
        {
            if (DataProcessedAsync != null)
            {
                await DataProcessedAsync(this, EventArgs.Empty);
            }
        }

        private bool CanDoSomething()
        {
            return true;
        }
        private bool CanDoAnotherSomething()
        {
            return true;
        }

        private async Task WorkMetod()
        {
            var i = 0;
            while (i < 19)
            {
                Title += ".";
                await Task.Delay(150);
                i++;
            }
        }

        private async void DoSomething()
        {

            //DataLoader loader = await DataLoader.CreateAsync();

            //Title = loader.Data;

            //await foreach (var number in GenerateNumberAsync())
            //{
            //    ExampleMultiAsync += $"Получено число - {number}\n";
            //}

            //string data = await GetDataCustomTaskASync();
            //AnotherTitle = data;


            //await FetchDataFromMultipleApisAsync();

            //Title = "Старт!";
            //await WorkMetod();
            //Title += "Финиш!";

            //AnotherTitle = await GetDataFromApiAsync("https://macademy.free.beeceptor.com/data");
            //// ExampleCancellation();
            ////ExampleExceptionTaskAsync();
            ///
            //await OnDataProcessedAsync();

            ExampleParallelClassAsync();
        }


        private void AddData(int value)
        {
            readerWriterLock.EnterWriteLock();
            try
            {
                dataInts.Add(value);
            }
            finally
            {
                readerWriterLock.EnterWriteLock();
            }
        }

        private int[] GetData()
        {
            readerWriterLock.EnterReadLock();
            try
            {
                return dataInts.ToArray();
            }
            finally
            {
                readerWriterLock.ExitReadLock();
            }
        }

        private void ExampleParallelClassAsync()
        {
            Parallel.For(0, 10, i =>
             {
                 ExampleMultiAsync += $"Итерация {i} начала выполнение \n";
                 Task.Delay(1000);
                 ExampleMultiEndAsync += $"Итерация {i} завершена\n";

             });
        }

        private async void DoAnotherSomething()
        {
            //Task task = new Task(async () =>
            //{
            //    await Task.Delay(1000);
            //    AnotherTitle = "Что-то сделали!";
            //});
            //task.Start();
            //await ExampleTaskRun();
            await ProcessUrlsWhithLimitAsync(apiUrl, 2);

            //await WriteTextToFileAsync("exampleAsync.txt", ExampleMultiAsync);

            //Title = await ReadTextFromFileAsync("exampleAsync.txt");

            DataProcessedAsync += async (sender, args) =>
            {
                await Task.Delay(500);
                Title = "Данные обработаны асинхронно!";
            };
        }


        public async Task UpdateSharedResouce()
        {
            await Task.Delay(600);
            lock (lockObject)
            {
                sharedResource++;
            }
        }

        private void DoWorkMonitor()
        {
            if (Monitor.TryEnter(lockObject, TimeSpan.FromSeconds(1)))
            {
                try
                {
                    sharedResource++;
                }
                finally
                {
                    Monitor.Exit(lockObject);
                }
            }
            else
            {
                LogError = "Не удалось получить блокировку!";
            }
        }



        public async Task WriteTextToFileAsync(string path, string content)
        {
            byte[] enicodeText = Encoding.Unicode.GetBytes(content);

            using (FileStream fs = new FileStream(path,
                FileMode.Create, FileAccess.Write, FileShare.None,
                bufferSize: 4096, useAsync: true))
            {
                await fs.WriteAsync(enicodeText, 0, enicodeText.Length);
            }
        }

        public async Task<string> ReadTextFromFileAsync(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException($"Не найден - {path}");

            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize: 4096, useAsync: true))
            {
                StringBuilder sb = new StringBuilder();

                byte[] buffer = new byte[0x1000];

                int numRead;
                while ((numRead = await fs.ReadAsync(buffer, 0, buffer.Length)) != 0)
                {
                    string text = Encoding.Unicode.GetString(buffer, 0, numRead);
                    sb.Append(text);
                }

                return sb.ToString();
            }
        }



        private async IAsyncEnumerable<int> GenerateNumberAsync()
        {
            for (int i = 0; i < 15; i++)
            {
                await Task.Delay(500);
                yield return i;
            }
        }

        public Task<string> GetDataCustomTaskASync()
        {
            var tcs = new TaskCompletionSource<string>();
            Timer timer = null;

            timer = new Timer(state =>
            {
                tcs.SetResult("Данные получены из произвольного источника");
                timer.Dispose();
            }, null, 2000, Timeout.Infinite);


            return tcs.Task;
        }


        private void DoWorkMutex()
        {
            using (var mutex = new Mutex(false, "Global\\MyMutex"))
            {
                if (mutex.WaitOne(TimeSpan.FromSeconds(5), false))
                {
                    Title = "Приложение запущено!";
                    return;
                }
            }
        }

        public async Task ProcessUrlsWhithLimitAsync(List<string> urls, int maxDegreeOfParallelism)
        {
            DataProcessedAsync += async (sender, args) =>
            {
                await Task.Delay(500);
                AnotherTitle = "Файлы обработаны асинхронно!";
            };


            using (SemaphoreSlim semaphore = new SemaphoreSlim(maxDegreeOfParallelism))
            {
                var task = urls.Select(async url =>
                {
                    await semaphore.WaitAsync();
                    try
                    {
                        var data = await GetDataFromApiAsync(url);
                        ExampleMultiAsync += $"Получены данные из - {url}\n";
                    }
                    finally
                    {
                        semaphore.Release();
                    }
                });

                await Task.WhenAll(task);
            }
        }

        //Так не надо
        //public async Task<string> GetConstantValueAsync()
        //{
        //    return "Const";
        //}

        public Task<string> GetConstantValueAsync()
        {
            return Task.FromResult("Const");
        }
        private async Task ExampleTaskRun()
        {
            await Task.Delay(1000);
            Task task = Task.Run(() =>
            {
                AnotherTitle += "( Что-то сделали через Task Run! )";
            });

            Task<int> taskInt = Task.Run(() =>
            {
                return 49;
            });
            taskInt.Wait();
            await taskInt.ContinueWith(t => { Title += t.Result; });

            await Task.WhenAll(task, taskInt);
        }

        public async Task<string> GetDataFromApiAsync(string url)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string date = await client.GetStringAsync(url);//.ConfigureAwait(false);
                    return date;
                }
            }
            catch (HttpRequestException ex)
            {
                LogError += " Задача завершилась с ошибкой - " + ex.Message;
                throw;
            }
        }

        public async Task FetchDataFromMultipleApisAsync()
        {


            var tasks = apiUrl.Select(url => GetDataFromApiAsync(url));

            var results = await Task.WhenAll(tasks);
            int i = 0;
            foreach (var result in results)
            {

                ExampleMultiAsync += $"Task {i}\n {result}\n+++++++++++++++++++++++++++++\n";
                i++;
            }


        }

        public async Task ExampleExceptionTaskAsync()
        {
            Task task = Task.Run(() =>
            {
                throw new InvalidOperationException("Ошибка задачи");
            });

            try
            {
                task.Wait();
            }
            catch (AggregateException ex)
            {
                foreach (Exception innerExceptions in ex.InnerExceptions)
                {
                    LogError = innerExceptions.Message;
                }

            }

            Task taskContinue = Task.Run(() =>
            {
                throw new InvalidOperationException("Ошибка задачи");
            });

            await taskContinue.ContinueWith(t =>
             {
                 if (t.IsFaulted)
                 {
                     LogError += " / Задача завершилась с ошибкой - " + t.Exception.Message;
                 }
             }
             );
        }

        private async Task ExampleCancellation()
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken cancellationToken = cts.Token;


            Task task = Task.Run(() =>
            {
                for (int i = 0; i < 1000; i++)
                {

                    cancellationToken.ThrowIfCancellationRequested();
                    AnotherTitle += "=";

                    Thread.Sleep(10);
                }
            }, cancellationToken);
            Thread.Sleep(1000);
            cts.Cancel();

            try
            {
                await task.WaitAsync(cancellationToken);
            }
            catch (AggregateException ex)
            {
                if (ex.InnerExceptions.Any(e => e is OperationCanceledException))
                {
                    LogError += "Задача была отменена";
                }
                else
                {
                    LogError += " / Задача завершилась с ошибкой - " + ex.InnerException?.Message;
                }
            }

        }




        public ApplicationViewModel()
        {
            newCommand = new DelegateCommand(DoSomething, CanDoSomething);
            anotherCommand = new DelegateCommand(DoAnotherSomething, CanDoAnotherSomething);
        }


    }
}
