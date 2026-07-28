using AvaloniaApplication1.ViewModels;
using AvaloniaApplication1.Views;
using Jab;

namespace AvaloniaApplication1.Services;

[ServiceProvider]
[Singleton<MainWindow>]
[Transient<MainWindowViewModel>]
[Transient<HomePageViewModel>]
[Singleton<INavigationService, NavigationService>]
[Singleton<INotificationService, NotificationService>]
[Singleton<IPageViewModelFactory>(Factory = nameof(CreatePageFactory))]
public partial class AppServiceProvider
{
    private IPageViewModelFactory CreatePageFactory() =>
        new PageViewModelFactory(pageId => pageId switch
        {
            0 => GetService<HomePageViewModel>(),
            1 => new DownloadPageViewModel(),
            2 => new SettingsPageViewModel(),
            _ => throw new ArgumentOutOfRangeException(nameof(pageId))
        });
}