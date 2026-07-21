using AvaloniaApplication1.ViewModels;
using Jab;

namespace AvaloniaApplication1.Services;

[ServiceProvider]
[Singleton<MainWindowViewModel>]
[Singleton<INavigateView, NavigateView>]
public partial class AppServiceProvider;