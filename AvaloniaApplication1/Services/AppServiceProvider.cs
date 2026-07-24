using AvaloniaApplication1.ViewModels;
using AvaloniaApplication1.Views;
using CommunityToolkit.Mvvm.Messaging;
using Jab;

namespace AvaloniaApplication1.Services;

[ServiceProvider]
[Singleton<MainWindow>(Factory = nameof(CreateWindowFactory))]
[Singleton<MainWindowViewModel>]
[Transient<HomePageViewModel>]
[Transient<SettingsPageViewModel>]
[Singleton<INavigationService, NavigationService>]
[Singleton<IMessenger>(Factory = nameof(CreateMessengerFactory))]
[Singleton<PageViewModelFactory>(Factory = nameof(CreatePageFactory))]
public partial class AppServiceProvider
{
    private MainWindow CreateWindowFactory() => new(GetService<IMessenger>())
        { DataContext = GetService<MainWindowViewModel>() };

    private IMessenger CreateMessengerFactory() => WeakReferenceMessenger.Default;

    private PageViewModelFactory CreatePageFactory() =>
        pageId => pageId switch
        {
            0 => GetService<HomePageViewModel>(),
            1 => GetService<SettingsPageViewModel>(),
            _ => null
        };
}

public delegate object? PageViewModelFactory(int pageId);