using MySixthProgram.UI.ViewModels;
using NLog;
using System.Configuration;
using System.Data;
using System.Windows;

namespace MySixthProgram.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

        protected override void OnStartup(StartupEventArgs e)
        {

            base.OnStartup(e);
            Logger.Info("Приложение запустилось");
            MainWindow app = new MainWindow();
            MainViewModel viewModel = new MainViewModel();
            app.DataContext = viewModel;
            app.Show();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            Logger.Info("Приложение завершило работу");
            LogManager.Shutdown();
            base.OnExit(e);
        }
    }

}
