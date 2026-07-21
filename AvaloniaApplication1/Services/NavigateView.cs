using Avalonia.Controls;
using AvaloniaApplication1.ViewModels;

namespace AvaloniaApplication1.Services;

public class NavigateView : INavigateView
{
    private ContentControl _target = null!;

    public void SetTarget(ContentControl control) => _target = control;

    public void Navigate(int id) => _target.Content = id switch
    {
        1 => new HomePage(),
        2 => new SettingsPage { DataContext = new SettingsPageViewModel() },
        _ => throw new ArgumentOutOfRangeException(nameof(id), id, null)
    };
}

public interface INavigateView
{
    void SetTarget(ContentControl control);

    void Navigate(int id);
}