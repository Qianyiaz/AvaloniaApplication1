namespace AvaloniaApplication1.Services;

public interface INavigationService
{
    event Action<int>? Navigated;

    bool CanGoBack { get; }

    void Navigate(int pageId);

    void GoBack();
}

public class NavigationService : INavigationService
{
    private readonly Stack<int> _navigationStack = new();

    public event Action<int>? Navigated;

    public bool CanGoBack => _navigationStack.Count > 1;

    public void Navigate(int pageId)
    {
        _navigationStack.Push(pageId);
        Navigated?.Invoke(pageId);
    }

    public void GoBack()
    {
        if (!CanGoBack) throw new InvalidOperationException("Cannot go back.");

        _navigationStack.Pop();
        Navigated?.Invoke(_navigationStack.Peek());
    }
}