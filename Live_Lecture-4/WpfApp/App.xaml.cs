using System.Windows;
using WpfApp.Services;
using WpfApp.ViewModels;

namespace WpfApp
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var navigationHandler = new NavigationHandler();
            navigationHandler.CurrentViewModel = new AllCasesViewModel(navigationHandler);

            MainWindow = new MainWindow
            {
                DataContext = new MainViewModel(navigationHandler)
            };

            MainWindow.Show();
            base.OnStartup(e);
        }

    }
}
