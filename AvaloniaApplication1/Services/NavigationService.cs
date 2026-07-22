using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaApplication1.Services;

public interface INavigationService
{
    int CurrentPageId { get; }

    bool IsCanGoBack { get; }

    event Action<int>? Navigated;

    void Navigate(int pageId);

    void GoBack();
}

public partial class NavigationService : ObservableObject, INavigationService
{
    private readonly Stack<int> _backStack = new();

    [ObservableProperty] public partial int CurrentPageId { get; private set; } = -1;

    public bool IsCanGoBack => _backStack.Count > 0;

    public event Action<int>? Navigated;

    public void Navigate(int pageId)
    {
        if (pageId == CurrentPageId)
            return;

        if (CurrentPageId >= 0)
            _backStack.Push(CurrentPageId);

        ShowPage(pageId);
    }

    public void GoBack()
    {
        if (IsCanGoBack)
            ShowPage(_backStack.Pop());
    }

    private void ShowPage(int pageId)
    {
        CurrentPageId = pageId;
        Navigated?.Invoke(pageId);
        OnPropertyChanged(nameof(IsCanGoBack));
    }
}