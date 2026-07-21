using AvaloniaApplication1.ViewModels;
using Jab;

namespace AvaloniaApplication1.Services;

[ServiceProvider]
[Singleton<MainWindow>(Factory = nameof(MainWindowServiceFactory))]
[Transient<HomePage>]
[Transient<SettingsPage>(Factory = nameof(SettingsPageServiceFactory))]
[Singleton<MainWindowViewModel>]
[Transient<SettingsPageViewModel>]
[Singleton<INavigateView, NavigateView>]
public partial class AppServiceProvider
{
    public MainWindow MainWindowServiceFactory() => new() { DataContext = GetService<MainWindowViewModel>() };

    public SettingsPage SettingsPageServiceFactory() => new() { DataContext = GetService<SettingsPageViewModel>() };
}