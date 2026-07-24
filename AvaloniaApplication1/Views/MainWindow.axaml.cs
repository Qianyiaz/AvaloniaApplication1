using Avalonia.Controls;
using Avalonia.Controls.Notifications;
using CommunityToolkit.Mvvm.Messaging;

namespace AvaloniaApplication1.Views;

public partial class MainWindow : Window
{
    public MainWindow(IMessenger messenger)
    {
        InitializeComponent();

        messenger.Register<Notification>(this,
            (_, notification) => NotificationManager.Show(notification));
    }
}