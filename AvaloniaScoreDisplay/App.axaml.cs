using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using AvaloniaScoreDisplay.ViewModels;
using AvaloniaScoreDisplay.Views;
using log4net;
using log4net.Config;

namespace AvaloniaScoreDisplay
{
    public partial class App : Application
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(App));
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow
                {
                    DataContext = new MainWindowViewModel(),
                };
            }

            base.OnFrameworkInitializationCompleted();
            XmlConfigurator.Configure(); // Load the Log4Net configuration from log4net.config
            log.Debug("Application started");
        }
    }
}