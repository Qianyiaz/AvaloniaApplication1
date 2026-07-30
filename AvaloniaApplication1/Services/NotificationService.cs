using Avalonia.Controls.Notifications;

namespace AvaloniaApplication1.Services;

public interface INotificationService
{
    void Initialize(WindowNotificationManager manager);

    void Show(INotification notification);

    void Close(INotification notification);

    void CloseAll();
}

public class NotificationService : INotificationService
{
    private WindowNotificationManager _manager = null!;

    public void Initialize(WindowNotificationManager manager) => _manager = manager;

    public void Show(INotification notification) => _manager.Show(notification);

    public void Close(INotification notification) => _manager.Close(notification);

    public void CloseAll() => _manager.CloseAll();
}