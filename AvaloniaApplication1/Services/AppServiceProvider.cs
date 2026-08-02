using AvaloniaApplication1.ViewModels;
using AvaloniaApplication1.Views;
using Jab;

namespace AvaloniaApplication1.Services;

[ServiceProvider]
[Singleton<MainWindow>]
[Transient<MainWindowViewModel>]
[Transient<HomePageViewModel>]
[Transient<DownloadPageViewModel>]
[Singleton<INavigationService, NavigationService>]
[Singleton<INotificationService, NotificationService>]
[Singleton<PageViewModelFactory>(Factory = nameof(CreatePageFactory))]
public partial class AppServiceProvider
{
    private PageViewModelFactory CreatePageFactory() => pageId => pageId switch
    {
        0 => GetService<HomePageViewModel>(),
        1 => GetService<DownloadPageViewModel>(),
        2 => new SettingsPageViewModel(),
        _ => throw new ArgumentOutOfRangeException(nameof(pageId))
    };
}

public delegate object PageViewModelFactory(int pageId);