using AvaloniaApplication1.ViewModels;
using Jab;

namespace AvaloniaApplication1.Services;

[ServiceProvider]
[Singleton<MainWindowViewModel>]
[Singleton<INavigationService, NavigationService>]
public partial class AppServiceProvider;