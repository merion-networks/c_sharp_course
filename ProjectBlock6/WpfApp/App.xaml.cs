using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Windows;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider serviceProvider;

        public App()
        {
            ServiceCollection serviceDescriptors = new ServiceCollection();
            CofigureServices(serviceDescriptors);
            serviceProvider = serviceDescriptors.BuildServiceProvider();
        }

        private void CofigureServices(ServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddScoped<ApplicationViewModel>();
            serviceDescriptors.AddSingleton<MainWindow>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            MainWindow app = new MainWindow();
            ApplicationViewModel viewModel = new ApplicationViewModel();

            app.DataContext = viewModel;
            app.Show();
        }


    }

}
