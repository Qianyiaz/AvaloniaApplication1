using AvaloniaApplication1.ViewModels;
using AvaloniaApplication1.Views;
using Jab;

namespace AvaloniaApplication1.Services;

[ServiceProvider]
[Singleton<MainWindow>]
[Transient<MainWindowViewModel>]
[Singleton<INotificationService, NotificationService>]
public partial class AppServiceProvider;