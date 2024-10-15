using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using UniqueIdGenerator.ViewModels;
using UniqueIdGenerator.Views;

namespace UniqueIdGenerator;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    /// <summary>
    /// <see cref="IServiceProvider"/>
    /// </summary>
    private IServiceProvider serviceProvider;

    public App()
    {
        IServiceCollection serviceCollection = new ServiceCollection();

        serviceCollection.AddTransient<MainWindowViewModel>();
        serviceCollection.AddTransient<MainWindow>();

        this.serviceProvider = serviceCollection.BuildServiceProvider();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var window = serviceProvider.GetService<MainWindow>()
            ?? throw new NullReferenceException();

        window.Show();
    }
}
