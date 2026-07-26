using Avalonia.Controls;
using Avalonia.Controls.Notifications;

namespace AvaloniaApplication1.Services;

public interface INotificationService
{
    void Initialize(TopLevel topLevel);

    void Show(INotification notification);

    void Close(INotification notification);

    void CloseAll();
}

public class NotificationService : INotificationService
{
    private WindowNotificationManager _manager = null!;

    public void Initialize(TopLevel topLevel) => _manager = new(topLevel) { MaxItems = 4 };

    public void Show(INotification notification) => _manager.Show(notification);

    public void Close(INotification notification) => _manager.Close(notification);

    public void CloseAll() => _manager.CloseAll();
}