using Avalonia.Controls;

namespace AvaloniaApplication1.Services;

public class NavigateView(IServiceProvider sp) : INavigateView
{
    public ContentControl Target { get; set; } = null!;

    public void Navigate(int id) => Target.Content = id switch
    {
        1 => sp.GetService(typeof(HomePage)),
        2 => sp.GetService(typeof(SettingsPage)),
        _ => throw new ArgumentOutOfRangeException(nameof(id), id, null)
    };
}

public interface INavigateView
{
    ContentControl Target { get; set; }

    void Navigate(int id);
}