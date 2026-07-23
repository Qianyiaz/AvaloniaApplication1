namespace AvaloniaApplication1.Services;

public interface INavigationService
{
    bool CanGoBack { get; }

    event Action<int>? Navigated;

    void Navigate(int pageId);

    void GoBack();
}

public class NavigationService : INavigationService
{
    private readonly Stack<int> _navigationStack = new();

    public bool CanGoBack => _navigationStack.Count > 1;

    public event Action<int>? Navigated;

    public void Navigate(int pageId)
    {
        if (_navigationStack.Count > 0 && _navigationStack.Peek() == pageId)
            return;

        _navigationStack.Push(pageId);
        Navigated?.Invoke(pageId);
    }

    public void GoBack()
    {
        if (!CanGoBack) return;

        _navigationStack.Pop();
        Navigated?.Invoke(_navigationStack.Peek());
    }
}