using Avalonia.Controls.Notifications;
using AvaloniaApplication1.ViewModels;
using AvaloniaApplication1.Views;
using Jab;

namespace AvaloniaApplication1.Services;

[ServiceProvider]
[Singleton<MainWindow>]
[Transient<MainWindowViewModel>]
[Transient<HomePageViewModel>]
[Transient<SettingsPageViewModel>]
[Singleton<INavigationService, NavigationService>]
[Singleton<Func<int, object>>(Factory = nameof(CreatePageFactory))]
[Singleton<INotificationManager>(Factory = nameof(CreateNotificationManager))]
public partial class AppServiceProvider
{
    private WindowNotificationManager CreateNotificationManager() => new(GetService<MainWindow>()) { MaxItems = 3 };

    private Func<int, object> CreatePageFactory() =>
        pageId => pageId switch
        {
            0 => GetService<HomePageViewModel>(),
            1 => GetService<SettingsPageViewModel>(),
            _ => throw new ArgumentOutOfRangeException(nameof(pageId))
        };
}