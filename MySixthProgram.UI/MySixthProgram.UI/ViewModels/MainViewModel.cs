using MySixthProgram.UI.Models;
using NLog;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MySixthProgram.UI.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private readonly ILogger _logger;
        private CancellationTokenSource cancellationTokenSource;

        private int maxConcurrentOperations = 5;

        public ObservableCollection<OperationModel> Operations { get; set; }

        public ICommand StartOperationsCommand { get; set; }
        public ICommand CancelOperationsCommand { get; set; }

        public int MaxConcurrentOperations
        {
            get { return maxConcurrentOperations; }
            set { SetProperty(ref maxConcurrentOperations, value); }
        }

        public MainViewModel()
        {
            _logger = LogManager.GetCurrentClassLogger();
            Operations = new ObservableCollection<OperationModel>();
            StartOperationsCommand = new DelegateCommand(StartOperation);
            CancelOperationsCommand = new DelegateCommand(CancelOperation);

            InitializeOperations();
        }

        private void InitializeOperations()
        {
            for (int i = 0; i <= 20; i++)
            {
                Operations.Add(new OperationModel { Name = $"Operation {i}", Status = "Ожидание" });
            }
        }

        private void CancelOperation()
        {
            try
            {
                cancellationTokenSource.Cancel();
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
            }
        }

        private async void StartOperation()
        {
            foreach (var operation in Operations)
            {
                operation.Progress = 0;
            }

            cancellationTokenSource = new CancellationTokenSource();
            var semaphore = new SemaphoreSlim(MaxConcurrentOperations);

            var tasks = Operations.Select(operation =>
            RunOperationAsync(operation, semaphore, cancellationTokenSource.Token)).ToList();

            try
            {
                await Task.WhenAll(tasks);

            }
            catch (OperationCanceledException)
            {
                _logger.Info("Операция была отменена");
            }
            finally
            {
                semaphore.Dispose(); cancellationTokenSource.Dispose();
            }
        }
        private async Task RunOperationAsync(OperationModel operation, SemaphoreSlim semaphore, CancellationToken token)
        {
            await semaphore.WaitAsync(token);

            try
            {
                operation.Status = "Выполняется";
                var progress = new Progress<int>(value => operation.Progress = value);

                await Task.Run(() => PerfomMathOperation(operation, progress, token), token);

                operation.Status = "Завершено";

                _logger.Info($"Операция {operation.Name} была выполнена успешно!");
            }
            catch (OperationCanceledException)
            {
                operation.Status = "Отменена";
                _logger.Info($"Операция {operation.Name} была отменена");
            }
            catch (Exception ex)
            {
                operation.Status = "Ошибка";
                _logger.Error($"Операция {operation.Name} была завершена с ошибкой {ex.Message}");

            }
            finally
            {
                semaphore.Release();
            }
        }

        private async Task PerfomOperation(OperationModel operation, IProgress<int> progress, CancellationToken token)
        {
            for (int i = 0; i < 1500; i++)
            {
                token.ThrowIfCancellationRequested();
                Thread.Sleep(20);
                progress.Report(i);
            }

        }

        private async Task PerfomMathOperation(OperationModel operation, IProgress<int> progress, CancellationToken token)
        {
            int totalIntegration = 10_000_000;

            for (int i = 0; i < totalIntegration; i++)
            {
                token.ThrowIfCancellationRequested();

                double result = Math.Sqrt(i) * Math.Sin(i);
                if (i % 1000 == 0)
                {
                    int procentComplite = (int)((double)i / totalIntegration * 100);
                    progress.Report(procentComplite);
                }
            }
        }
    }
}
