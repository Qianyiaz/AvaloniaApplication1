using AvaloniaApplication1.ViewModels;
using Jab;

namespace AvaloniaApplication1.Services;

[ServiceProvider]
[Singleton<MainWindow>(Factory = nameof(MainWindowServiceFactory))]
[Singleton<MainWindowViewModel>]
[Transient<HomePage>]
[Transient<SettingsPage>]
[Singleton<INavigateView, NavigateView>]
public partial class AppServiceProvider
{
    public MainWindow MainWindowServiceFactory() => new() { DataContext = GetService<MainWindowViewModel>() };
}